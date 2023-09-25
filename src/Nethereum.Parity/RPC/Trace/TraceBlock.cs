using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Nethereum.Parity.RPC.Trace
{
    /// <Summary>
    ///     Returns traces created at given block
    /// </Summary>
    public class TraceBlock : RpcRequestResponseHandler<JArray>, ITraceBlock
    {
        public TraceBlock(IClient client) : base(client, ApiMethods.trace_block.ToString())
        {
        }

        public Task<JArray> SendRequestAsync(HexBigInteger blockNumber, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, blockNumber);
        }

        public RpcRequest BuildRequest(HexBigInteger blockNumber, object id = null)
        {
            return base.BuildRequest(id, blockNumber);
        }
    }
}