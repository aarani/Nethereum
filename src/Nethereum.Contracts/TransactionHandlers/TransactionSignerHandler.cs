﻿using System.Threading;
using System.Threading.Tasks;
using Nethereum.Contracts.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.TransactionManagers;

namespace Nethereum.Contracts.TransactionHandlers
{
#if !DOTNET35
    /// <summary>
    /// Signs a transaction estimating the gas if not set and retrieving the next nonce if not set
    /// </summary>
    public class TransactionSignerHandler<TFunctionMessage> :
        TransactionHandlerBase<TFunctionMessage>,
        ITransactionSigner<TFunctionMessage>
        where TFunctionMessage : FunctionMessage, new()
    {
        private readonly ITransactionEstimatorHandler<TFunctionMessage> _contractTransactionEstimatorHandler;


        public TransactionSignerHandler(ITransactionManager transactionManager) : this(transactionManager,
            new TransactionEstimatorHandler<TFunctionMessage>(transactionManager))
        {

        }

        public TransactionSignerHandler(ITransactionManager transactionManager,
            ITransactionEstimatorHandler<TFunctionMessage> contractTransactionEstimatorHandler) : base(transactionManager)
        {
            _contractTransactionEstimatorHandler = contractTransactionEstimatorHandler;
        }



        public async Task<string> SignTransactionAsync(string contractAddress,
                                                       TFunctionMessage functionMessage = null,
                                                       CancellationToken cancellationToken = default(CancellationToken))
        {
            if(functionMessage == null) functionMessage = new TFunctionMessage();
            SetEncoderContractAddress(contractAddress);
            functionMessage.Gas = await GetOrEstimateMaximumGasAsync(functionMessage,
                                                                     contractAddress,
                                                                     cancellationToken)
                .ConfigureAwait(false);
            var transactionInput = FunctionMessageEncodingService.CreateTransactionInput(functionMessage);
            return await TransactionManager.SignTransactionAsync(transactionInput,
                                                                 cancellationToken)
                .ConfigureAwait(false);
        }

        protected virtual async Task<HexBigInteger> GetOrEstimateMaximumGasAsync(
            TFunctionMessage functionMessage, string contractAddress,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return functionMessage.GetHexMaximumGas()
                   ?? await _contractTransactionEstimatorHandler.EstimateGasAsync(contractAddress,
                                                                                  functionMessage,
                                                                                  cancellationToken).ConfigureAwait(false);
        }
    }
#endif
}