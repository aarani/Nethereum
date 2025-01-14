#if !DOTNET35
using System;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client.RpcMessages;

namespace Nethereum.JsonRpc.Client
{
    public abstract class ClientBase : IClient
    {

        public static TimeSpan ConnectionTimeout { get; set; } = TimeSpan.FromSeconds(20.0);

        public RequestInterceptor OverridingRequestInterceptor { get; set; }

        public async Task<T> SendRequestAsync<T>(RpcRequest request, string route = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (OverridingRequestInterceptor != null)
                return
                    (T)
                    await OverridingRequestInterceptor.InterceptSendRequestAsync(SendInnerRequestAsync<T>, request, route)
                        .ConfigureAwait(false);
            return await SendInnerRequestAsync<T>(request, route, cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<RpcRequestResponseBatch> SendBatchRequestAsync(RpcRequestResponseBatch rpcRequestResponseBatch)
        {
            var responses = await SendAsync(rpcRequestResponseBatch.GetRpcRequests()).ConfigureAwait(false);
            rpcRequestResponseBatch.UpdateBatchItemResponses(responses);
            return rpcRequestResponseBatch;
        }

        public async Task<T> SendRequestAsync<T>(string method, string route = null, CancellationToken cancellationToken = default(CancellationToken), params object[] paramList)
        {
            if (OverridingRequestInterceptor != null)
                return
                    (T)
                    await OverridingRequestInterceptor.InterceptSendRequestAsync(SendInnerRequestAsync<T>, method, route,
                        cancellationToken,
                        paramList).ConfigureAwait(false);
            return await SendInnerRequestAsync<T>(method, route, cancellationToken, paramList).ConfigureAwait(false);
        }

        protected void HandleRpcError(RpcResponseMessage response, string reqMsg)
        {
            if (response.HasError)
                throw new RpcResponseException(new RpcError(response.Error.Code, response.Error.Message + ": " + reqMsg,
                    response.Error.Data));
        }

        private async Task<T> SendInnerRequestAsync<T>(RpcRequestMessage reqMsg,
                                                       string route = null,
                                                       CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await SendAsync(reqMsg, route, cancellationToken).ConfigureAwait(false);
            HandleRpcError(response, reqMsg.Method);
            try
            {
                return response.GetResult<T>();
            }
            catch (FormatException formatException)
            {
                throw new RpcResponseFormatException("Invalid format found in RPC response", formatException);
            }
        }

        protected virtual Task<T> SendInnerRequestAsync<T>(RpcRequest request, string route = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var reqMsg = new RpcRequestMessage(request.Id,
                                               request.Method,
                                               request.RawParameters);
            return SendInnerRequestAsync<T>(reqMsg, route, cancellationToken);
        }

        protected virtual Task<T> SendInnerRequestAsync<T>(string method, string route = null,
            CancellationToken cancellationToken = default(CancellationToken),
            params object[] paramList)
        {
            var request = new RpcRequestMessage(Guid.NewGuid().ToString(), method, paramList);
            return SendInnerRequestAsync<T>(request, route, cancellationToken);
        }

        public virtual async Task SendRequestAsync(RpcRequest request, string route = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response =
                await SendAsync(
                        new RpcRequestMessage(request.Id, request.Method, request.RawParameters), route, cancellationToken)
                    .ConfigureAwait(false);
            HandleRpcError(response, request.Method);
        }

        protected abstract Task<RpcResponseMessage> SendAsync(RpcRequestMessage rpcRequestMessage, string route = null, CancellationToken cancellationToken = default(CancellationToken));
        protected abstract Task<RpcResponseMessage[]> SendAsync(RpcRequestMessage[] requests, CancellationToken cancellationToken = default(CancellationToken));
        public virtual async Task SendRequestAsync(string method, string route = null, CancellationToken cancellationToken = default(CancellationToken), params object[] paramList)
        {
            var request = new RpcRequestMessage(Guid.NewGuid().ToString(), method, paramList);
            var response = await SendAsync(request, route, cancellationToken).ConfigureAwait(false);
            HandleRpcError(response, method);
        }
    }
}
#endif