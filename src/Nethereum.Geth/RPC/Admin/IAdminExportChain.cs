using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Geth.RPC.Admin
{
    public interface IAdminExportChain
    {
        RpcRequest BuildRequest(string file, object id = null);
        Task<bool> SendRequestAsync(string file, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string file, long first, object id = null);
        Task<bool> SendRequestAsync(string file, long first, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string file, long first, long last, object id = null);
        Task<bool> SendRequestAsync(string file, long first, long last, object id = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}