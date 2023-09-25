using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Besu.RPC.Clique
{
    public interface ICliqueDiscard
    {
        Task<bool> SendRequestAsync(string addressSigner, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string addressSigner, object id = null);
    }
}