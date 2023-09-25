﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Quorum.RPC
{
    public class QuorumVote : RpcRequestResponseHandler<string>, IQuorumVote
    {
        public QuorumVote(IClient client) : base(client, ApiMethods.quorum_vote.ToString())
        {
        }

        public Task<string> SendRequestAsync(string hash, object id = null,
                                             CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hash == null) throw new ArgumentNullException(nameof(hash));
            return base.SendRequestAsync(id, cancellationToken, hash.EnsureHexPrefix());
        }

        public RpcRequest BuildRequest(string hash, object id = null)
        {
            if (hash == null) throw new ArgumentNullException(nameof(hash));
            return base.BuildRequest(id, hash.EnsureHexPrefix());
        }
    }
}