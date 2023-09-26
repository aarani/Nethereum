
using Nethereum.JsonRpc.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.Quorum.RPC.Permission
{
    ///<Summary>
    /// Approves the recovery of the specified denylisted (blacklisted) account. This method can be called by a network admin account. Once a majority of the network admins approve, the account is marked as active.
    /// 
    /// Parameters
    /// orgId: string - organization or sub-organization ID to which the node belongs
    /// 
    /// acctId: string - denylisted account ID
    /// 
    /// Returns
    /// result: string - response message    
    ///</Summary>
    public interface IQuorumPermissionApproveBlackListedAccountRecovery
    {
        Task<string> SendRequestAsync(string orgId, string acctId, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(string orgId, string acctId, object id = null);
    }

    ///<Summary>
/// Approves the recovery of the specified denylisted (blacklisted) account. This method can be called by a network admin account. Once a majority of the network admins approve, the account is marked as active.
/// 
/// Parameters
/// orgId: string - organization or sub-organization ID to which the node belongs
/// 
/// acctId: string - denylisted account ID
/// 
/// Returns
/// result: string - response message    
///</Summary>
    public class QuorumPermissionApproveBlackListedAccountRecovery : RpcRequestResponseHandler<string>, IQuorumPermissionApproveBlackListedAccountRecovery
    {
        public QuorumPermissionApproveBlackListedAccountRecovery(IClient client) : base(client,ApiMethods.quorumPermission_approveBlackListedAccountRecovery.ToString()) { }

        public Task<string> SendRequestAsync(string orgId, string acctId, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, orgId, acctId);
        }
        public RpcRequest BuildRequest(string orgId, string acctId, object id = null)
        {
            return base.BuildRequest(id, orgId, acctId);
        }
    }

}

