using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Besu.RPC.IBFT
{
    /// <Summary>
    ///     Proposes adding or removing a validator with the specified address.
    /// </Summary>
    public class IbftProposeValidatorVote : RpcRequestResponseHandler<bool>, IIbftProposeValidatorVote
    {
        public IbftProposeValidatorVote(IClient client) : base(client, ApiMethods.ibft_proposeValidatorVote.ToString())
        {
        }

        public Task<bool> SendRequestAsync(string accountAddress, bool addValidator, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, accountAddress, addValidator);
        }

        public RpcRequest BuildRequest(string accountAddress, bool addValidator, object id = null)
        {
            return base.BuildRequest(id, accountAddress, addValidator);
        }
    }
}