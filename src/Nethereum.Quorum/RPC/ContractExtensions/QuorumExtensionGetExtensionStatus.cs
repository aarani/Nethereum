
using Nethereum.JsonRpc.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.Quorum.RPC.ContractExtensions
{
    ///<Summary>
    /// Retrieves the status of the specified contract extension.
    /// 
    /// Parameters
    /// managementContractAddress: string - address of the extension management contract
    /// 
    /// Returns
    /// result: string - status of contract extension (ACTIVE or DONE)    
    ///</Summary>
    public interface IQuorumExtensionGetExtensionStatus
    {
        Task<string> SendRequestAsync(string managementContractAddress, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string managementContractAddress, object id = null);
    }

    ///<Summary>
/// Retrieves the status of the specified contract extension.
/// 
/// Parameters
/// managementContractAddress: string - address of the extension management contract
/// 
/// Returns
/// result: string - status of contract extension (ACTIVE or DONE)    
///</Summary>
    public class QuorumExtensionGetExtensionStatus : RpcRequestResponseHandler<string>, IQuorumExtensionGetExtensionStatus
    {
        public QuorumExtensionGetExtensionStatus(IClient client) : base(client,ApiMethods.quorumExtension_getExtensionStatus.ToString()) { }

        public Task<string> SendRequestAsync(string managementContractAddress, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, managementContractAddress);
        }
        public RpcRequest BuildRequest(string managementContractAddress, object id = null)
        {
            return base.BuildRequest(id, managementContractAddress);
        }
    }

}

