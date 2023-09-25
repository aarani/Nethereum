using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;

namespace Nethereum.Web3.Accounts
{
    public class AccountTransactionSigningInterceptor : RequestInterceptor
    {
        private readonly AccountSignerTransactionManager _signer;

        public AccountTransactionSigningInterceptor(string privateKey, BigInteger chainId, IClient client)
        {
            _signer = new AccountSignerTransactionManager(client, privateKey, chainId);
        }

        public override async Task<object> InterceptSendRequestAsync<TResponse>(
            Func<RpcRequest, string, CancellationToken, Task<TResponse>> interceptedSendRequestAsync, RpcRequest request,
            string route = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request.Method == "eth_sendTransaction")
            {
                var transaction = (TransactionInput) request.RawParameters[0];
                return await SignAndSendTransactionAsync(transaction, cancellationToken).ConfigureAwait(false);
            }

            return await base.InterceptSendRequestAsync(interceptedSendRequestAsync, request, route, cancellationToken)
                .ConfigureAwait(false);
        }

        public override async Task<object> InterceptSendRequestAsync<T>(
            Func<string, string, CancellationToken, object[], Task<T>> interceptedSendRequestAsync, string method,
            string route = null, CancellationToken cancellationToken = default(CancellationToken),
            params object[] paramList)
        {
            if (method == "eth_sendTransaction")
            {
                var transaction = (TransactionInput) paramList[0];
                return await SignAndSendTransactionAsync(transaction, cancellationToken).ConfigureAwait(false);
            }

            return await base.InterceptSendRequestAsync(interceptedSendRequestAsync, method, route, cancellationToken, paramList)
                .ConfigureAwait(false);
        }

        private Task<string> SignAndSendTransactionAsync(TransactionInput transaction,
                                                         CancellationToken cancellationToken = default(CancellationToken))
        {
            return _signer.SendTransactionAsync(transaction, cancellationToken);
        }
    }
}