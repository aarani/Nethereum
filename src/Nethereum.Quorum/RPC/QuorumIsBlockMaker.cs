﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Quorum.RPC
{
    public class QuorumIsBlockMaker : RpcRequestResponseHandler<bool>, IQuorumIsBlockMaker
    {
        public QuorumIsBlockMaker(IClient client) : base(client, ApiMethods.quorum_isBlockMaker.ToString())
        {
        }

        public Task<bool> SendRequestAsync(string address, object id = null,
                                           CancellationToken cancellationToken = default(CancellationToken))
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            return base.SendRequestAsync(id, cancellationToken, address.EnsureHexPrefix());
        }

        public RpcRequest BuildRequest(string address, object id = null)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            return base.BuildRequest(id, address.EnsureHexPrefix());
        }
    }
}