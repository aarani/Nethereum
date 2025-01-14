﻿using Nethereum.GSN.Interfaces;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nethereum.GSN
{
    public class GSNTransactionInterceptor : RequestInterceptor
    {
        private readonly IGSNTransactionManager _transactionManager;

        public GSNTransactionInterceptor(IGSNTransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }

        public override async Task<object> InterceptSendRequestAsync<TResponse>(
            Func<RpcRequest, string, CancellationToken, Task<TResponse>> interceptedSendRequestAsync,
            RpcRequest request,
            string route = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request.Method == "eth_sendTransaction")
            {
                var transaction = (TransactionInput)request.RawParameters[0];
                return await _transactionManager.SendTransactionAsync(transaction)
                    .ConfigureAwait(false);
            }

            if (request.Method == "eth_sendRawTransaction")
            {
                // TODO: Implement logic to handle signed transactions in gsn
            }

            return await base.InterceptSendRequestAsync(interceptedSendRequestAsync, request, route, cancellationToken)
                .ConfigureAwait(false);
        }

        public override async Task<object> InterceptSendRequestAsync<T>(
            Func<string, string, CancellationToken, object[], Task<T>> interceptedSendRequestAsync,
            string method,
            string route = null, CancellationToken cancellationToken = default(CancellationToken),
            params object[] paramList)
        {
            if (method == "eth_sendTransaction")
            {
                var transaction = (TransactionInput)paramList[0];
                return await _transactionManager.SendTransactionAsync(transaction)
                    .ConfigureAwait(false);
            }

            return await base.InterceptSendRequestAsync(interceptedSendRequestAsync, method, route, cancellationToken, paramList)
                .ConfigureAwait(false);
        }
    }
}
