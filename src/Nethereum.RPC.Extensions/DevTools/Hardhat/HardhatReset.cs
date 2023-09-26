
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Infrastructure;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.RPC.Extensions.DevTools.Hardhat
{

///<Summary>
/// .    
///</Summary>
    public class HardhatReset : RpcRequestResponseHandler<string>
    {
        public HardhatReset(IClient client, ApiMethods apiMethod) : base(client, apiMethod.ToString()) { }
        public HardhatReset(IClient client) : base(client, ApiMethods.hardhat_reset.ToString()) { }

        public Task SendRequestAsync(object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken);
        }

        public RpcRequest BuildRequest(object id = null)
        {
            return base.BuildRequest(id);
        }
    }

}
