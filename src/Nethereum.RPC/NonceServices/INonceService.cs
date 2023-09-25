
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;

namespace Nethereum.RPC.NonceServices
{
    public interface INonceService
    {
        IClient Client { get; set; }
        Task<HexBigInteger> GetNextNonceAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task ResetNonceAsync();
    }
}