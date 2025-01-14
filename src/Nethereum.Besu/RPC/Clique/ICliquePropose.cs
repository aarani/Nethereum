using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Besu.RPC.Clique
{
    public interface ICliquePropose
    {
        Task<bool> SendRequestAsync(string address, bool addSigner, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string address, bool addSigner, object id = null);
    }
}