
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.Quorum.RPC.Privacy
{
    ///<Summary>
    /// Retrieve the details of a privacy marker transaction‘s internal private transaction using the PMT’s transaction hash.
    /// 
    /// Parameters
    /// string - privacy marker transaction’s hash in hex format
    /// Returns
    /// object - private transaction (nil if caller is not a participant)    
    ///</Summary>
    public interface IEthGetPrivateTransactionByHash
    {
        Task<Transaction> SendRequestAsync(string privacyMarkerTransactionHash, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string privacyMarkerTransactionHash, object id = null);
    }

    ///<Summary>
/// Retrieve the details of a privacy marker transaction‘s internal private transaction using the PMT’s transaction hash.
/// 
/// Parameters
/// string - privacy marker transaction’s hash in hex format
/// Returns
/// object - private transaction (nil if caller is not a participant)    
///</Summary>
    public class EthGetPrivateTransactionByHash : RpcRequestResponseHandler<Transaction>, IEthGetPrivateTransactionByHash
    {
        public EthGetPrivateTransactionByHash(IClient client) : base(client,ApiMethods.eth_getPrivateTransactionByHash.ToString()) { }

        public Task<Transaction> SendRequestAsync(string privacyMarkerTransactionHash, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, privacyMarkerTransactionHash);
        }
        public RpcRequest BuildRequest(string privacyMarkerTransactionHash, object id = null)
        {
            return base.BuildRequest(id, privacyMarkerTransactionHash);
        }
    }

}

