using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Besu.RPC.Admin
{
    /// <Summary>
    ///     Removes a static node.
    /// </Summary>
    public class AdminRemovePeer : RpcRequestResponseHandler<bool>, IAdminRemovePeer
    {
        public AdminRemovePeer(IClient client) : base(client, ApiMethods.admin_removePeer.ToString())
        {
        }

        public Task<bool> SendRequestAsync(string enodeUrl, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, enodeUrl);
        }

        public RpcRequest BuildRequest(string enodeUrl, object id = null)
        {
            return base.BuildRequest(id, enodeUrl);
        }
    }
}