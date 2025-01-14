﻿using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.RPC.Extensions.DevTools.Evm
{
    ///<Summary>
    /// Sets the gas limit for future blocks    
    ///</Summary>
    public class EvmSetBlockGasLimit : RpcRequestResponseHandler<string>
    {
        public EvmSetBlockGasLimit(IClient client) : base(client, ApiMethods.evm_setBlockGasLimit.ToString()) { }

        public Task<string> SendRequestAsync(HexBigInteger blockGasLimit, object id = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SendRequestAsync(id, cancellationToken, blockGasLimit);
        }
        public RpcRequest BuildRequest(HexBigInteger blockGasLimit, object id = null)
        {
            return base.BuildRequest(id, blockGasLimit);
        }
    }

}
    
