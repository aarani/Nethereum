using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.RPC.DebugNode
{
    public interface IDebugGetRawBlock
    {
        RpcRequest BuildRequest(BlockParameter block, object id = null);
        Task<string> SendRequestAsync(object id = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<string> SendRequestAsync(BlockParameter block, object id = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}