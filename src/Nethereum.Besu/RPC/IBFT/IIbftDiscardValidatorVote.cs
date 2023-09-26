using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Besu.RPC.IBFT
{
    public interface IIbftDiscardValidatorVote
    {
        Task<bool> SendRequestAsync(string validatorAddress, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string validatorAddress, object id = null);
    }
}