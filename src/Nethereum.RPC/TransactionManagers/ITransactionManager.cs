﻿using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using System.Threading;
using Nethereum.RPC.Accounts;
using Nethereum.RPC.Fee1559Suggestions;
using Nethereum.RPC.TransactionReceipts;

namespace Nethereum.RPC.TransactionManagers
{
    public interface ITransactionManager
    {
        IClient Client { get; set; }
        BigInteger DefaultGasPrice { get; set; }
        BigInteger DefaultGas { get; set; }
        IAccount Account { get; }
        bool UseLegacyAsDefault { get; set; }
#if !DOTNET35
        IFee1559SuggestionStrategy Fee1559SuggestionStrategy { get; set; }

        Task<string> SendTransactionAsync(TransactionInput transactionInput,
                                          CancellationToken cancellationToken = default(CancellationToken));
        Task<HexBigInteger> EstimateGasAsync(CallInput callInput,
                                             CancellationToken cancellationToken = default(CancellationToken));
        Task<string> SendTransactionAsync(string from, string to, HexBigInteger amount,
                                          CancellationToken cancellationToken = default(CancellationToken));
        Task<string> SignTransactionAsync(TransactionInput transaction,
                                          CancellationToken cancellationToken = default(CancellationToken));
        ITransactionReceiptService TransactionReceiptService { get; set; }
        bool CalculateOrSetDefaultGasPriceFeesIfNotSet { get; set; }
        bool EstimateOrSetDefaultGasIfNotSet { get; set; }
        Task<TransactionReceipt> SendTransactionAndWaitForReceiptAsync(TransactionInput transactionInput, CancellationToken cancellationToken = default);
#endif

    }
}
