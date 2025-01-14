﻿using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;

namespace Nethereum.Geth.RPC.Miner
{
    public interface IMinerStart
    {
        RpcRequest BuildRequest(int number, object id = null);
        Task<bool> SendRequestAsync(object id = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SendRequestAsync(int number, object id = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}