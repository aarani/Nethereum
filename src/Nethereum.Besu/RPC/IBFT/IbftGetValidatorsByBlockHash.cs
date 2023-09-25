using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Besu.RPC.IBFT
{
    /// <Summary>
    ///     Lists the validators defined in the specified block.
    /// </Summary>
    public class IbftGetValidatorsByBlockHash : RpcRequestResponseHandler<string[]>, IIbftGetValidatorsByBlockHash
    {
        public IbftGetValidatorsByBlockHash(IClient client) : base(client,
            ApiMethods.ibft_getValidatorsByBlockHash.ToString())
        {
        }

        public Task<string[]> SendRequestAsync(string blockHash, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, blockHash);
        }

        public RpcRequest BuildRequest(string blockHash, object id = null)
        {
            return base.BuildRequest(id, blockHash);
        }
    }
}