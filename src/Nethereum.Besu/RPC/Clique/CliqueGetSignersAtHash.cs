using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Besu.RPC.Clique
{
    public interface ICliqueGetSignersAtHash
    {
        Task<string[]> SendRequestAsync(string blockHash, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string blockHash, object id = null);
    }

    /// <Summary>
    ///     Lists signers for the specified block.
    /// </Summary>
    public class CliqueGetSignersAtHash : RpcRequestResponseHandler<string[]>, ICliqueGetSignersAtHash
    {
        public CliqueGetSignersAtHash(IClient client) : base(client, ApiMethods.clique_getSignersAtHash.ToString())
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