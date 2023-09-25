using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;
using Nethereum.Besu.RPC.EEA.DTOs;
using System.Threading;

namespace Nethereum.Besu.RPC.EEA
{
    public interface IEeaGetTransactionReceipt
    {
        Task<EeaTransactionReceipt> SendRequestAsync(string transactionHash, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string transactionHash, object id = null);
    }
}