using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Newtonsoft.Json.Linq;

namespace Nethereum.RPC.DebugNode
{

    public class DebugGetRawTransaction : RpcRequestResponseHandler<string>, IDebugGetRawTransaction
    {
        public DebugGetRawTransaction(IClient client)
            : base(client, ApiMethods.debug_getRawTransaction.ToString())
        {
        }

        public Task<string> SendRequestAsync(string transactionHash, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (transactionHash == null) throw new ArgumentNullException(nameof(transactionHash));
            return base.SendRequestAsync(id, cancellationToken, transactionHash);
        }


        public RpcRequest BuildRequest(string transactionHash, object id = null)
        {
            if (transactionHash == null) throw new ArgumentNullException(nameof(transactionHash));
            return base.BuildRequest(id, transactionHash);
        }
    }
}