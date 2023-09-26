using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Geth.RPC.Admin
{
    public interface IAdminStartRPC
    {
        RpcRequest BuildRequest(string host, int port, string cors, string api, object id = null);
        Task<bool> SendRequestAsync(object id = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SendRequestAsync(string host, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SendRequestAsync(string host, int port, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SendRequestAsync(string host, int port, string cors, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SendRequestAsync(string host, int port, string cors, string api, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string host, int port, string cors, string api, string vHosts, object id = null);
        Task<bool> SendRequestAsync(string host, int port, string cors, string api, string vHosts, object id = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}