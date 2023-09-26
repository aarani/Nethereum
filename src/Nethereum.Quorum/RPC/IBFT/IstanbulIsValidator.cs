
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.Quorum.RPC.IBFT
{
    ///<Summary>
    /// Indicates if this node is the validator for the specified block number.
    /// 
    /// Parameters
    /// blockNumber: number - (optional) block number; defaults to latest block number
    /// 
    /// Returns
    /// result: boolean - true if this node is the validator for the given blockNumber, otherwise false    
    ///</Summary>
    public interface IIstanbulIsValidator
    {
        Task<bool> SendRequestAsync(BlockParameter blockNumber, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        RpcRequest BuildRequest(BlockParameter blockNumber, object id = null);
    }

    ///<Summary>
/// Indicates if this node is the validator for the specified block number.
/// 
/// Parameters
/// blockNumber: number - (optional) block number; defaults to latest block number
/// 
/// Returns
/// result: boolean - true if this node is the validator for the given blockNumber, otherwise false    
///</Summary>
    public class IstanbulIsValidator : RpcRequestResponseHandler<bool>, IIstanbulIsValidator
    {
        public IstanbulIsValidator(IClient client) : base(client,ApiMethods.istanbul_isValidator.ToString()) { }

        public Task<bool> SendRequestAsync(BlockParameter blockNumber, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, blockNumber.GetRPCParamAsNumber());
        }
        public RpcRequest BuildRequest(BlockParameter blockNumber, object id = null)
        {
            return base.BuildRequest(id, blockNumber.GetRPCParamAsNumber());
        }
    }

}

