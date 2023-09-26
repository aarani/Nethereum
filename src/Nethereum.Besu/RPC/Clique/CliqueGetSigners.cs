using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;

namespace Nethereum.Besu.RPC.Clique
{
    public interface ICliqueGetSigners
    {
        Task<string[]> SendRequestAsync(BlockParameter blockParameter, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(BlockParameter blockParameter, object id = null);
    }

    /// <Summary>
    ///     Lists signers for the specified block.
    /// </Summary>
    public class CliqueGetSigners : RpcRequestResponseHandler<string[]>, ICliqueGetSigners
    {
        public CliqueGetSigners(IClient client) : base(client, ApiMethods.clique_getSigners.ToString())
        {
        }

        public Task<string[]> SendRequestAsync(BlockParameter blockParameter, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, blockParameter);
        }

        public RpcRequest BuildRequest(BlockParameter blockParameter, object id = null)
        {
            return base.BuildRequest(id, blockParameter);
        }
    }
}