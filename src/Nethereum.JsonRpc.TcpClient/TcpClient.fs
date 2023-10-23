namespace Nethereum.JsonRpc.TcpClient

open Microsoft.Extensions.Logging
open System
open System.Buffers
open System.Net
open System.Net.Sockets
open System.IO.Pipelines
open System.Text
open System.Threading.Tasks

open Newtonsoft.Json

open Nethereum.JsonRpc.Client
open Nethereum.JsonRpc.Client.RpcMessages

type Either<'Val> =
    | FailureResult
    | SuccessfulValue of 'Val

type TcpClient(asyncResolveHost: unit->Async<IPAddress>, port, maybeSerializationSettings: JsonSerializerSettings, log: ILogger) =
    inherit ClientBase()
    let minimumBufferSize = 1024
    let serializationSettings =
        if isNull maybeSerializationSettings then
            DefaultJsonSerializerSettingsFactory.BuildDefaultJsonSerializerSettings()
        else
            maybeSerializationSettings

    let WithTimeout (timeSpan: TimeSpan) (job: Async<'R>) : Async<Option<'R>> =
        async {
            let read =
                async {
                    let! value = job
                    return value |> SuccessfulValue |> Some
                }

            let delay =
                async {
                    let total = int timeSpan.TotalMilliseconds
                    do! Async.Sleep total
                    return FailureResult |> Some
                }

            let! dummyOption = Async.Choice [ read; delay ]

            match dummyOption with
            | Some theResult ->
                match theResult with
                | SuccessfulValue r -> return Some r
                | FailureResult _ -> return None
            | None ->
                // none of the jobs passed to Async.Choice returns None
                return failwith "unreachable"
        }


    let UnwrapTimeoutOption timeoutMsg job = async {
        let! maybeRes = job
        match maybeRes with
        | None ->
            return raise <| RpcClientTimeoutException timeoutMsg
        | Some res ->
            return res
    }

    let rec WriteToPipeAsync (writer: PipeWriter) (socket: Socket) = async {
        try
            let segment = Array.zeroCreate<byte> minimumBufferSize |> ArraySegment
            let! read = socket.ReceiveAsync(segment, SocketFlags.None)
                        |> Async.AwaitTask |> WithTimeout ClientBase.ConnectionTimeout |> UnwrapTimeoutOption "Socket read timed out"

            match read with
            | 0 ->
                return writer.Complete()
            | bytesRead ->
                segment.Array.CopyTo(writer.GetMemory bytesRead)
                writer.Advance bytesRead
                let! cancelToken = Async.CancellationToken
                let! flusher = (writer.FlushAsync cancelToken).AsTask() |> Async.AwaitTask
                if flusher.IsCompleted then
                    return writer.Complete()
                else
                    cancelToken.ThrowIfCancellationRequested()
                    return! WriteToPipeAsync writer socket
        with
        | ex -> return writer.Complete ex
    }

    let rec ReadFromPipeAsync (reader: PipeReader) (state: StringBuilder * int) = async {
        let! cancelToken = Async.CancellationToken
        let! result = (reader.ReadAsync cancelToken).AsTask() |> Async.AwaitTask

        let mutable buffer = result.Buffer
        let sb = fst state

        let str = BuffersExtensions.ToArray(& buffer) |> Encoding.UTF8.GetString
        str |> sb.Append |> ignore
        let bracesCount = str |> Seq.sumBy (function | '{' -> 1 | '}' -> -1 | _ -> 0)

        reader.AdvanceTo buffer.End

        let braces = (snd state) + bracesCount
        if result.IsCompleted || braces = 0 then
            return sb.ToString()
        else
            cancelToken.ThrowIfCancellationRequested()
            return! ReadFromPipeAsync reader (sb, braces)
    }

    let AsyncRequestImpl (json: string) =
        async {
            let! endpoint = asyncResolveHost() |> WithTimeout ClientBase.ConnectionTimeout |> UnwrapTimeoutOption "Name resolution timed out"

            let! cancelToken = Async.CancellationToken
            cancelToken.ThrowIfCancellationRequested()

            use socket = new Socket(SocketType.Stream, ProtocolType.Tcp)
            let! _connect = socket.ConnectAsync(endpoint, port)
                           |> Async.AwaitTask |> WithTimeout ClientBase.ConnectionTimeout |> UnwrapTimeoutOption "Socket connect timed out"

            cancelToken.ThrowIfCancellationRequested()

            let segment = UTF8Encoding.UTF8.GetBytes(json + Environment.NewLine) |> ArraySegment
            let! _send = socket.SendAsync(segment, SocketFlags.None)
                        |> Async.AwaitTask |> WithTimeout ClientBase.ConnectionTimeout |> UnwrapTimeoutOption "Socket send timed out"

            cancelToken.ThrowIfCancellationRequested()

            let pipe = Pipe()
            let! _ = WriteToPipeAsync pipe.Writer socket |> Async.StartChild
            return! ReadFromPipeAsync pipe.Reader (StringBuilder(), 0)
        }

    new(asyncResolveHost: unit->Async<IPAddress>, port) =
        TcpClient(asyncResolveHost, port, null, null)
    new(asyncResolveHost: unit->Async<IPAddress>, port, serializerSettings) =
        TcpClient(asyncResolveHost, port, serializerSettings, null)
    new (asyncResolveHost: unit->Async<IPAddress>, port, logger) =
        TcpClient(asyncResolveHost, port, null, logger)

    new(resolveHostAsync: Func<Task<IPAddress>>, port) =
        let asyncResolveHost() =
            resolveHostAsync.Invoke()
            |> Async.AwaitTask
        TcpClient(asyncResolveHost, port, null, null)
    new(resolveHostAsync: Func<Task<IPAddress>>, port, serializerSettings) =
        let asyncResolveHost() =
            resolveHostAsync.Invoke()
            |> Async.AwaitTask
        TcpClient(asyncResolveHost, port, serializerSettings, null)
    new (resolveHostAsync: Func<Task<IPAddress>>, port, logger) =
        let asyncResolveHost() =
            resolveHostAsync.Invoke()
            |> Async.AwaitTask
        TcpClient(asyncResolveHost, port, null, logger)

    member __.AsyncSendRaw (json: string) =
        async {
            try
                return! AsyncRequestImpl json
            with
            | :? AggregateException as ae when ae.Flatten().InnerExceptions
                    |> Seq.exists (fun x -> x :? SocketException ||
                                            x :? TimeoutException) ->
                return raise <| RpcClientUnknownException(ae.Message, ae)
            | :? SocketException as ex ->
                return raise <| RpcClientUnknownException(ex.Message, ex)
        }

    member self.SendRawAsync (json: string) =
        self.AsyncSendRaw json |> Async.StartAsTask

    member self.AsyncSend (request: RpcRequestMessage, _route: string) =
        async {
            let rpcLogger = RpcLogger log
            
            let rpcRequestJson = JsonConvert.SerializeObject(request, serializationSettings)
            rpcLogger.LogRequest rpcRequestJson
            
            let! rawResponse = self.AsyncSendRaw rpcRequestJson
            
            let response = JsonConvert.DeserializeObject<RpcResponseMessage>(rawResponse, serializationSettings)
            rpcLogger.LogResponse response
            
            return response
        }

    override self.SendAsync(request: RpcRequestMessage, route: string) =
        self.AsyncSend (request, route)
        |> Async.StartAsTask

    member self.AsyncSend (requests: array<RpcRequestMessage>) =
        async {
            let rpcLogger = RpcLogger log
            
            let rpcRequestJson = JsonConvert.SerializeObject(requests, serializationSettings)
            rpcLogger.LogRequest rpcRequestJson

            let! rawResponse = self.AsyncSendRaw rpcRequestJson
            return JsonConvert.DeserializeObject<array<RpcResponseMessage>>(rawResponse, serializationSettings)
        }

    override self.SendAsync(requests: array<RpcRequestMessage>) =
        self.AsyncSend requests
        |> Async.StartAsTask
