
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.RPC.Extensions.DevTools.Hardhat
{

///<Summary>
/// Sets the balance for the given address.    
///</Summary>
    public class HardhatSetBalance : RpcRequestResponseHandler<string>
    {
        public HardhatSetBalance(IClient client, ApiMethods apiMethod) : base(client, apiMethod.ToString()) { }
        public HardhatSetBalance(IClient client) : base(client,ApiMethods.hardhat_setBalance.ToString()) { }

        public Task<string> SendRequestAsync(string address, HexBigInteger balance, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, address, balance);
        }
        public RpcRequest BuildRequest(string address, HexBigInteger balance, object id = null)
        {
            return base.BuildRequest(id, address, balance);
        }
    }

}

