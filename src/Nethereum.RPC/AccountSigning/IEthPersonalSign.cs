using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.RPC.AccountSigning
{
    public interface IEthPersonalSign : IEthereumMessageSign
    {
        RpcRequest BuildRequest(byte[] value, object id = null);
        RpcRequest BuildRequest(HexUTF8String utf8Hex, object id = null);
    }

    public interface IEthereumMessageSign
    {
        Task<string> SendRequestAsync(byte[] value, object id = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<string> SendRequestAsync(HexUTF8String utf8Hex, object id = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}