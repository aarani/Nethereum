using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;
using System.Threading;

namespace Nethereum.RPC.Eth
{
    /// <Summary>
    ///     eth_getBalance
    ///     Returns the balance of the account of given address.
    ///     Parameters
    ///     DATA, 20 Bytes - address to check for balance.
    ///     QUANTITY|TAG - integer block number, or the string "latest", "earliest" or "pending", see the default block
    ///     parameter
    ///     params: [
    ///     '0x407d73d8a49eeb85d32cf465507dd71d507100c1',
    ///     'latest'
    ///     ]
    ///     Returns
    ///     QUANTITY - integer of the current balance in wei.
    ///     Example
    ///     Request
    ///     curl -X POST --data
    ///     '{"jsonrpc":"2.0","method":"eth_getBalance","params":["0x407d73d8a49eeb85d32cf465507dd71d507100c1",
    ///     "latest"],"id":1}'
    ///     Result
    ///     {
    ///     "id":1,
    ///     "jsonrpc": "2.0",
    ///     "result": "0x0234c8a3397aab58" // 158972490234375000
    ///     }
    /// </Summary>
    public class EthGetBalance : RpcRequestResponseHandler<HexBigInteger>, IDefaultBlock, IEthGetBalance
    {
        public EthGetBalance() : this(null)
        {
        }

        public EthGetBalance(IClient client) : base(client, ApiMethods.eth_getBalance.ToString())
        {
            DefaultBlock = BlockParameter.CreateLatest();
        }

        public BlockParameter DefaultBlock { get; set; }

        public Task<HexBigInteger> SendRequestAsync(string address,
                                                    BlockParameter block,
                                                    object id = null,
                                                    CancellationToken cancellationToken = default(CancellationToken))
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            if (block == null) throw new ArgumentNullException(nameof(block));
            return base.SendRequestAsync(id, cancellationToken, address.EnsureHexPrefix(), block);
        }

        public Task<HexBigInteger> SendRequestAsync(string address,
                                                    object id = null,
                                                    CancellationToken cancellationToken = default(CancellationToken))
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            return base.SendRequestAsync(id, cancellationToken, address.EnsureHexPrefix(), DefaultBlock);
        }

        public RpcRequestResponseBatchItem<EthGetBalance, HexBigInteger> CreateBatchItem(string address, BlockParameter block, object id)
        {
            return new RpcRequestResponseBatchItem<EthGetBalance, HexBigInteger>(this, BuildRequest(address, block, id));
        }

        public RpcRequestResponseBatchItem<EthGetBalance, HexBigInteger> CreateBatchItem(string address, object id)
        {
            return new RpcRequestResponseBatchItem<EthGetBalance, HexBigInteger>(this, BuildRequest(address, DefaultBlock, id));
        }

#if !DOTNET35
        public async Task<List<HexBigInteger>> SendBatchRequestAsync(string[] addresses, BlockParameter block)
        {
            var batchRequest = new RpcRequestResponseBatch();
            for (int i = 0; i < addresses.Length; i++)
            {
                batchRequest.BatchItems.Add(CreateBatchItem(addresses[i], block, i));
            }

            var response = await Client.SendBatchRequestAsync(batchRequest);
            return response.BatchItems.Select(x => ((RpcRequestResponseBatchItem<EthGetBalance, HexBigInteger>)x).Response).ToList();

        }

        public Task<List<HexBigInteger>> SendBatchRequestAsync(params string[] addresses)
        {
            return SendBatchRequestAsync(addresses, DefaultBlock);    
        }
#endif

        public RpcRequest BuildRequest(string address, BlockParameter block, object id = null)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            if (block == null) throw new ArgumentNullException(nameof(block));
            return base.BuildRequest(id, address.EnsureHexPrefix(), block);
        }

    }
}