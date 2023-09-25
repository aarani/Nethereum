using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Besu.RPC.Permissioning
{
    public interface IPermRemoveNodesFromWhitelist
    {
        Task<string> SendRequestAsync(string[] addresses, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string[] addresses, object id = null);
    }
}