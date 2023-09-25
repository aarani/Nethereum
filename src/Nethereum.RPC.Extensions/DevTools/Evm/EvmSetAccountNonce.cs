
using Nethereum.JsonRpc.Client;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using System.Threading;

namespace Nethereum.RPC.Extensions.DevTools.Evm
{

///<Summary>
/// Sets the given account's nonce to the specified value. Mines a new block before returning.
/// 
/// Warning: this will result in an invalid state tree.    
///</Summary>
    public class EvmSetAccountNonce : RpcRequestResponseHandler<bool>
    {
        public EvmSetAccountNonce(IClient client) : base(client,ApiMethods.evm_setAccountNonce.ToString()) { }

        public Task<bool> SendRequestAsync(string address, HexBigInteger nonce, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, address, nonce);
        }
        public RpcRequest BuildRequest(string address, HexBigInteger nonce, object id = null)
        {
            return base.BuildRequest(id, address, nonce);
        }
    }

}

