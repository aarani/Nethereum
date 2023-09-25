using System.Threading;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Rsk.RPC.RskEth.DTOs;

namespace Nethereum.Rsk.RPC.RskEth
{
    public interface IRskEthGetBlockWithTransactionsHashesByNumber
    {
        Task<RskBlockWithTransactionHashes> SendRequestAsync(HexBigInteger number, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<RskBlockWithTransactionHashes> SendRequestAsync(BlockParameter blockParameter, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(HexBigInteger number, object id = null);
        RpcRequest BuildRequest(BlockParameter blockParameter, object id = null);
    }
}