using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.AccountSigning;
using Nethereum.Signer;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.Accounts.AccountMessageSigning
{
    public class EthPersonalExternalSign : IEthPersonalSign
    {
        private readonly IEthExternalSigner _ethExternalSigner;

        public EthPersonalExternalSign(IEthExternalSigner ethExternalSigner)
        {
            _ethExternalSigner = ethExternalSigner;
        }

        public async Task<string> SendRequestAsync(byte[] value, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _ethExternalSigner.SignEthereumMessageAsync(value).ConfigureAwait(false);
            return EthECDSASignature.CreateStringSignature(result);
        }

        public Task<string> SendRequestAsync(HexUTF8String utf8Hex, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return SendRequestAsync(utf8Hex.HexValue.HexToByteArray(), cancellationToken: cancellationToken);
        }

        public RpcRequest BuildRequest(HexUTF8String utf8Hex, object id = null)
        {
            throw new NotImplementedException();
        }

        public RpcRequest BuildRequest(byte[] value, object id = null)
        {
            throw new NotImplementedException();
        }
    }
}
