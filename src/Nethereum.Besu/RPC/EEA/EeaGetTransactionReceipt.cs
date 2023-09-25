using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;
using Nethereum.Besu.RPC.EEA.DTOs;
using System.Threading;

namespace Nethereum.Besu.RPC.EEA
{
    /// <Summary>
    ///     Returns information about the private transaction after the transaction was mined. Receipts for pending
    ///     transactions are not available.
    /// </Summary>
    public class EeaGetTransactionReceipt : RpcRequestResponseHandler<EeaTransactionReceipt>, IEeaGetTransactionReceipt
    {
        public EeaGetTransactionReceipt(IClient client) : base(client, ApiMethods.eea_getTransactionReceipt.ToString())
        {
        }

        public Task<EeaTransactionReceipt> SendRequestAsync(string transactionHash, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, transactionHash);
        }

        public RpcRequest BuildRequest(string transactionHash, object id = null)
        {
            return base.BuildRequest(id, transactionHash);
        }
    }
}