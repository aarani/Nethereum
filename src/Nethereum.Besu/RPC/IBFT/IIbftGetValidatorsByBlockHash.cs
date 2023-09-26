using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Besu.RPC.IBFT
{
    public interface IIbftGetValidatorsByBlockHash
    {
        Task<string[]> SendRequestAsync(string blockHash, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string blockHash, object id = null);
    }
}