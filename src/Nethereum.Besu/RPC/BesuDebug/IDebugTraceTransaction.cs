using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;
using Newtonsoft.Json.Linq;

namespace Nethereum.Besu.RPC.Debug
{
    public interface IDebugTraceTransaction
    {
        Task<JObject> SendRequestAsync(string transactionHash, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string transactionHash, object id = null);
    }
}