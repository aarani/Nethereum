using System;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;

namespace Nethereum.RPC.DebugNode
{
    public class DebugGetRawReceipts : RpcRequestResponseHandler<string[]>, IDebugGetRawReceipts
    {
        public DebugGetRawReceipts(IClient client)
            : base(client, ApiMethods.debug_getRawReceipts.ToString())
        {
        }

        public Task<string[]> SendRequestAsync(BlockParameter block, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (block == null) throw new ArgumentNullException(nameof(block));
            return base.SendRequestAsync(id, cancellationToken, block);
        }

        public Task<string[]> SendRequestAsync(object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return SendRequestAsync(BlockParameter.CreateLatest(), cancellationToken, id);
        }

        public RpcRequest BuildRequest(BlockParameter block, object id = null)
        {
            if (block == null) throw new ArgumentNullException(nameof(block));
            return base.BuildRequest(id, block);
        }
    }
}