
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.RPC.Extensions.DevTools.Hardhat
{

///<Summary>
/// Sets the coinbase address to be used in new blocks    
///</Summary>
    public class HardhatSetNextBlockBaseFeePerGas : RpcRequestResponseHandler<string>
    {
        public HardhatSetNextBlockBaseFeePerGas(IClient client, ApiMethods apiMethod) : base(client, apiMethod.ToString()) { }
        public HardhatSetNextBlockBaseFeePerGas(IClient client) : base(client,ApiMethods.hardhat_setNextBlockBaseFeePerGas.ToString()) { }

        public Task SendRequestAsync(HexBigInteger baseFeePerGas, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, baseFeePerGas);
        }
        public RpcRequest BuildRequest(HexBigInteger baseFeePerGas, object id = null)
        {
            return base.BuildRequest(id, baseFeePerGas);
        }
    }

}

