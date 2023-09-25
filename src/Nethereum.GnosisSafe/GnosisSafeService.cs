using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.ContractHandlers;
using System.Threading;
using Nethereum.GnosisSafe.ContractDefinition;

namespace Nethereum.GnosisSafe
{
    public partial class GnosisSafeService
    {
        
        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public GnosisSafeService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

      

        public Task<string> AddOwnerWithThresholdRequestAsync(AddOwnerWithThresholdFunction addOwnerWithThresholdFunction)
        {
             return ContractHandler.SendRequestAsync(addOwnerWithThresholdFunction);
        }

        public Task<TransactionReceipt> AddOwnerWithThresholdRequestAndWaitForReceiptAsync(AddOwnerWithThresholdFunction addOwnerWithThresholdFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addOwnerWithThresholdFunction, cancellationToken);
        }

        public Task<string> AddOwnerWithThresholdRequestAsync(string owner, BigInteger threshold)
        {
            var addOwnerWithThresholdFunction = new AddOwnerWithThresholdFunction();
                addOwnerWithThresholdFunction.Owner = owner;
                addOwnerWithThresholdFunction.Threshold = threshold;
            
             return ContractHandler.SendRequestAsync(addOwnerWithThresholdFunction);
        }

        public Task<TransactionReceipt> AddOwnerWithThresholdRequestAndWaitForReceiptAsync(string owner, BigInteger threshold, CancellationToken cancellationToken = default(CancellationToken))
        {
            var addOwnerWithThresholdFunction = new AddOwnerWithThresholdFunction();
                addOwnerWithThresholdFunction.Owner = owner;
                addOwnerWithThresholdFunction.Threshold = threshold;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addOwnerWithThresholdFunction, cancellationToken);
        }

        public Task<string> ApproveHashRequestAsync(ApproveHashFunction approveHashFunction)
        {
             return ContractHandler.SendRequestAsync(approveHashFunction);
        }

        public Task<TransactionReceipt> ApproveHashRequestAndWaitForReceiptAsync(ApproveHashFunction approveHashFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveHashFunction, cancellationToken);
        }

        public Task<string> ApproveHashRequestAsync(byte[] hashToApprove)
        {
            var approveHashFunction = new ApproveHashFunction();
                approveHashFunction.HashToApprove = hashToApprove;
            
             return ContractHandler.SendRequestAsync(approveHashFunction);
        }

        public Task<TransactionReceipt> ApproveHashRequestAndWaitForReceiptAsync(byte[] hashToApprove, CancellationToken cancellationToken = default(CancellationToken))
        {
            var approveHashFunction = new ApproveHashFunction();
                approveHashFunction.HashToApprove = hashToApprove;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveHashFunction, cancellationToken);
        }

        public Task<BigInteger> ApprovedHashesQueryAsync(ApprovedHashesFunction approvedHashesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ApprovedHashesFunction, BigInteger>(approvedHashesFunction, blockParameter);
        }

        
        public Task<BigInteger> ApprovedHashesQueryAsync(string returnValue1, byte[] returnValue2, BlockParameter blockParameter = null)
        {
            var approvedHashesFunction = new ApprovedHashesFunction();
                approvedHashesFunction.ReturnValue1 = returnValue1;
                approvedHashesFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<ApprovedHashesFunction, BigInteger>(approvedHashesFunction, blockParameter);
        }

        public Task<string> ChangeThresholdRequestAsync(ChangeThresholdFunction changeThresholdFunction)
        {
             return ContractHandler.SendRequestAsync(changeThresholdFunction);
        }

        public Task<TransactionReceipt> ChangeThresholdRequestAndWaitForReceiptAsync(ChangeThresholdFunction changeThresholdFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(changeThresholdFunction, cancellationToken);
        }

        public Task<string> ChangeThresholdRequestAsync(BigInteger threshold)
        {
            var changeThresholdFunction = new ChangeThresholdFunction();
                changeThresholdFunction.Threshold = threshold;
            
             return ContractHandler.SendRequestAsync(changeThresholdFunction);
        }

        public Task<TransactionReceipt> ChangeThresholdRequestAndWaitForReceiptAsync(BigInteger threshold, CancellationToken cancellationToken = default(CancellationToken))
        {
            var changeThresholdFunction = new ChangeThresholdFunction();
                changeThresholdFunction.Threshold = threshold;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(changeThresholdFunction, cancellationToken);
        }

        public Task<string> DisableModuleRequestAsync(DisableModuleFunction disableModuleFunction)
        {
             return ContractHandler.SendRequestAsync(disableModuleFunction);
        }

        public Task<TransactionReceipt> DisableModuleRequestAndWaitForReceiptAsync(DisableModuleFunction disableModuleFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(disableModuleFunction, cancellationToken);
        }

        public Task<string> DisableModuleRequestAsync(string prevModule, string module)
        {
            var disableModuleFunction = new DisableModuleFunction();
                disableModuleFunction.PrevModule = prevModule;
                disableModuleFunction.Module = module;
            
             return ContractHandler.SendRequestAsync(disableModuleFunction);
        }

        public Task<TransactionReceipt> DisableModuleRequestAndWaitForReceiptAsync(string prevModule, string module, CancellationToken cancellationToken = default(CancellationToken))
        {
            var disableModuleFunction = new DisableModuleFunction();
                disableModuleFunction.PrevModule = prevModule;
                disableModuleFunction.Module = module;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(disableModuleFunction, cancellationToken);
        }

        public Task<byte[]> DomainSeparatorQueryAsync(DomainSeparatorFunction domainSeparatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DomainSeparatorFunction, byte[]>(domainSeparatorFunction, blockParameter);
        }

        
        public Task<byte[]> DomainSeparatorQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DomainSeparatorFunction, byte[]>(null, blockParameter);
        }

        public Task<string> EnableModuleRequestAsync(EnableModuleFunction enableModuleFunction)
        {
             return ContractHandler.SendRequestAsync(enableModuleFunction);
        }

        public Task<TransactionReceipt> EnableModuleRequestAndWaitForReceiptAsync(EnableModuleFunction enableModuleFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(enableModuleFunction, cancellationToken);
        }

        public Task<string> EnableModuleRequestAsync(string module)
        {
            var enableModuleFunction = new EnableModuleFunction();
                enableModuleFunction.Module = module;
            
             return ContractHandler.SendRequestAsync(enableModuleFunction);
        }

        public Task<TransactionReceipt> EnableModuleRequestAndWaitForReceiptAsync(string module, CancellationToken cancellationToken = default(CancellationToken))
        {
            var enableModuleFunction = new EnableModuleFunction();
                enableModuleFunction.Module = module;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(enableModuleFunction, cancellationToken);
        }

        public Task<byte[]> EncodeTransactionDataQueryAsync(EncodeTransactionDataFunction encodeTransactionDataFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EncodeTransactionDataFunction, byte[]>(encodeTransactionDataFunction, blockParameter);
        }

        
        public Task<byte[]> EncodeTransactionDataQueryAsync(string to, BigInteger value, byte[] data, byte operation, BigInteger safeTxGas, BigInteger baseGas, BigInteger gasPrice, string gasToken, string refundReceiver, BigInteger nonce, BlockParameter blockParameter = null)
        {
            var encodeTransactionDataFunction = new EncodeTransactionDataFunction();
                encodeTransactionDataFunction.To = to;
                encodeTransactionDataFunction.Value = value;
                encodeTransactionDataFunction.Data = data;
                encodeTransactionDataFunction.Operation = operation;
                encodeTransactionDataFunction.SafeTxGas = safeTxGas;
                encodeTransactionDataFunction.BaseGas = baseGas;
                encodeTransactionDataFunction.GasPrice = gasPrice;
                encodeTransactionDataFunction.GasToken = gasToken;
                encodeTransactionDataFunction.RefundReceiver = refundReceiver;
                encodeTransactionDataFunction.Nonce = nonce;
            
            return ContractHandler.QueryAsync<EncodeTransactionDataFunction, byte[]>(encodeTransactionDataFunction, blockParameter);
        }

        public Task<string> ExecTransactionRequestAsync(ExecTransactionFunction execTransactionFunction)
        {
             return ContractHandler.SendRequestAsync(execTransactionFunction);
        }

        public Task<TransactionReceipt> ExecTransactionRequestAndWaitForReceiptAsync(ExecTransactionFunction execTransactionFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(execTransactionFunction, cancellationToken);
        }

        public Task<string> ExecTransactionRequestAsync(string to, BigInteger value, byte[] data, byte operation, BigInteger safeTxGas, BigInteger baseGas, BigInteger gasPrice, string gasToken, string refundReceiver, byte[] signatures)
        {
            var execTransactionFunction = new ExecTransactionFunction();
                execTransactionFunction.To = to;
                execTransactionFunction.Value = value;
                execTransactionFunction.Data = data;
                execTransactionFunction.Operation = operation;
                execTransactionFunction.SafeTxGas = safeTxGas;
                execTransactionFunction.BaseGas = baseGas;
                execTransactionFunction.GasPrice = gasPrice;
                execTransactionFunction.GasToken = gasToken;
                execTransactionFunction.RefundReceiver = refundReceiver;
                execTransactionFunction.Signatures = signatures;
            
             return ContractHandler.SendRequestAsync(execTransactionFunction);
        }

        public Task<TransactionReceipt> ExecTransactionRequestAndWaitForReceiptAsync(string to, BigInteger value, byte[] data, byte operation, BigInteger safeTxGas, BigInteger baseGas, BigInteger gasPrice, string gasToken, string refundReceiver, byte[] signatures, CancellationToken cancellationToken = default(CancellationToken))
        {
            var execTransactionFunction = new ExecTransactionFunction();
                execTransactionFunction.To = to;
                execTransactionFunction.Value = value;
                execTransactionFunction.Data = data;
                execTransactionFunction.Operation = operation;
                execTransactionFunction.SafeTxGas = safeTxGas;
                execTransactionFunction.BaseGas = baseGas;
                execTransactionFunction.GasPrice = gasPrice;
                execTransactionFunction.GasToken = gasToken;
                execTransactionFunction.RefundReceiver = refundReceiver;
                execTransactionFunction.Signatures = signatures;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(execTransactionFunction, cancellationToken);
        }

        public Task<string> ExecTransactionFromModuleRequestAsync(ExecTransactionFromModuleFunction execTransactionFromModuleFunction)
        {
             return ContractHandler.SendRequestAsync(execTransactionFromModuleFunction);
        }

        public Task<TransactionReceipt> ExecTransactionFromModuleRequestAndWaitForReceiptAsync(ExecTransactionFromModuleFunction execTransactionFromModuleFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(execTransactionFromModuleFunction, cancellationToken);
        }

        public Task<string> ExecTransactionFromModuleRequestAsync(string to, BigInteger value, byte[] data, byte operation)
        {
            var execTransactionFromModuleFunction = new ExecTransactionFromModuleFunction();
                execTransactionFromModuleFunction.To = to;
                execTransactionFromModuleFunction.Value = value;
                execTransactionFromModuleFunction.Data = data;
                execTransactionFromModuleFunction.Operation = operation;
            
             return ContractHandler.SendRequestAsync(execTransactionFromModuleFunction);
        }

        public Task<TransactionReceipt> ExecTransactionFromModuleRequestAndWaitForReceiptAsync(string to, BigInteger value, byte[] data, byte operation, CancellationToken cancellationToken = default(CancellationToken))
        {
            var execTransactionFromModuleFunction = new ExecTransactionFromModuleFunction();
                execTransactionFromModuleFunction.To = to;
                execTransactionFromModuleFunction.Value = value;
                execTransactionFromModuleFunction.Data = data;
                execTransactionFromModuleFunction.Operation = operation;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(execTransactionFromModuleFunction, cancellationToken);
        }

        public Task<string> ExecTransactionFromModuleReturnDataRequestAsync(ExecTransactionFromModuleReturnDataFunction execTransactionFromModuleReturnDataFunction)
        {
             return ContractHandler.SendRequestAsync(execTransactionFromModuleReturnDataFunction);
        }

        public Task<TransactionReceipt> ExecTransactionFromModuleReturnDataRequestAndWaitForReceiptAsync(ExecTransactionFromModuleReturnDataFunction execTransactionFromModuleReturnDataFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(execTransactionFromModuleReturnDataFunction, cancellationToken);
        }

        public Task<string> ExecTransactionFromModuleReturnDataRequestAsync(string to, BigInteger value, byte[] data, byte operation)
        {
            var execTransactionFromModuleReturnDataFunction = new ExecTransactionFromModuleReturnDataFunction();
                execTransactionFromModuleReturnDataFunction.To = to;
                execTransactionFromModuleReturnDataFunction.Value = value;
                execTransactionFromModuleReturnDataFunction.Data = data;
                execTransactionFromModuleReturnDataFunction.Operation = operation;
            
             return ContractHandler.SendRequestAsync(execTransactionFromModuleReturnDataFunction);
        }

        public Task<TransactionReceipt> ExecTransactionFromModuleReturnDataRequestAndWaitForReceiptAsync(string to, BigInteger value, byte[] data, byte operation, CancellationToken cancellationToken = default(CancellationToken))
        {
            var execTransactionFromModuleReturnDataFunction = new ExecTransactionFromModuleReturnDataFunction();
                execTransactionFromModuleReturnDataFunction.To = to;
                execTransactionFromModuleReturnDataFunction.Value = value;
                execTransactionFromModuleReturnDataFunction.Data = data;
                execTransactionFromModuleReturnDataFunction.Operation = operation;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(execTransactionFromModuleReturnDataFunction, cancellationToken);
        }

        public Task<BigInteger> GetChainIdQueryAsync(GetChainIdFunction getChainIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetChainIdFunction, BigInteger>(getChainIdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetChainIdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetChainIdFunction, BigInteger>(null, blockParameter);
        }

        public Task<GetModulesPaginatedOutputDTO> GetModulesPaginatedQueryAsync(GetModulesPaginatedFunction getModulesPaginatedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetModulesPaginatedFunction, GetModulesPaginatedOutputDTO>(getModulesPaginatedFunction, blockParameter);
        }

        public Task<GetModulesPaginatedOutputDTO> GetModulesPaginatedQueryAsync(string start, BigInteger pageSize, BlockParameter blockParameter = null)
        {
            var getModulesPaginatedFunction = new GetModulesPaginatedFunction();
                getModulesPaginatedFunction.Start = start;
                getModulesPaginatedFunction.PageSize = pageSize;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetModulesPaginatedFunction, GetModulesPaginatedOutputDTO>(getModulesPaginatedFunction, blockParameter);
        }

        public Task<List<string>> GetOwnersQueryAsync(GetOwnersFunction getOwnersFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetOwnersFunction, List<string>>(getOwnersFunction, blockParameter);
        }

        
        public Task<List<string>> GetOwnersQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetOwnersFunction, List<string>>(null, blockParameter);
        }

        public Task<byte[]> GetStorageAtQueryAsync(GetStorageAtFunction getStorageAtFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStorageAtFunction, byte[]>(getStorageAtFunction, blockParameter);
        }

        
        public Task<byte[]> GetStorageAtQueryAsync(BigInteger offset, BigInteger length, BlockParameter blockParameter = null)
        {
            var getStorageAtFunction = new GetStorageAtFunction();
                getStorageAtFunction.Offset = offset;
                getStorageAtFunction.Length = length;
            
            return ContractHandler.QueryAsync<GetStorageAtFunction, byte[]>(getStorageAtFunction, blockParameter);
        }

        public Task<BigInteger> GetThresholdQueryAsync(GetThresholdFunction getThresholdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetThresholdFunction, BigInteger>(getThresholdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetThresholdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetThresholdFunction, BigInteger>(null, blockParameter);
        }

        public Task<byte[]> GetTransactionHashQueryAsync(GetTransactionHashFunction getTransactionHashFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTransactionHashFunction, byte[]>(getTransactionHashFunction, blockParameter);
        }

        
        public Task<byte[]> GetTransactionHashQueryAsync(string to, BigInteger value, byte[] data, byte operation, BigInteger safeTxGas, BigInteger baseGas, BigInteger gasPrice, string gasToken, string refundReceiver, BigInteger nonce, BlockParameter blockParameter = null)
        {
            var getTransactionHashFunction = new GetTransactionHashFunction();
                getTransactionHashFunction.To = to;
                getTransactionHashFunction.Value = value;
                getTransactionHashFunction.Data = data;
                getTransactionHashFunction.Operation = operation;
                getTransactionHashFunction.SafeTxGas = safeTxGas;
                getTransactionHashFunction.BaseGas = baseGas;
                getTransactionHashFunction.GasPrice = gasPrice;
                getTransactionHashFunction.GasToken = gasToken;
                getTransactionHashFunction.RefundReceiver = refundReceiver;
                getTransactionHashFunction.Nonce = nonce;
            
            return ContractHandler.QueryAsync<GetTransactionHashFunction, byte[]>(getTransactionHashFunction, blockParameter);
        }

        public Task<bool> IsModuleEnabledQueryAsync(IsModuleEnabledFunction isModuleEnabledFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsModuleEnabledFunction, bool>(isModuleEnabledFunction, blockParameter);
        }

        
        public Task<bool> IsModuleEnabledQueryAsync(string module, BlockParameter blockParameter = null)
        {
            var isModuleEnabledFunction = new IsModuleEnabledFunction();
                isModuleEnabledFunction.Module = module;
            
            return ContractHandler.QueryAsync<IsModuleEnabledFunction, bool>(isModuleEnabledFunction, blockParameter);
        }

        public Task<bool> IsOwnerQueryAsync(IsOwnerFunction isOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsOwnerFunction, bool>(isOwnerFunction, blockParameter);
        }

        
        public Task<bool> IsOwnerQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var isOwnerFunction = new IsOwnerFunction();
                isOwnerFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<IsOwnerFunction, bool>(isOwnerFunction, blockParameter);
        }

        public Task<BigInteger> NonceQueryAsync(NonceFunction nonceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NonceFunction, BigInteger>(nonceFunction, blockParameter);
        }

        
        public Task<BigInteger> NonceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NonceFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> RemoveOwnerRequestAsync(RemoveOwnerFunction removeOwnerFunction)
        {
             return ContractHandler.SendRequestAsync(removeOwnerFunction);
        }

        public Task<TransactionReceipt> RemoveOwnerRequestAndWaitForReceiptAsync(RemoveOwnerFunction removeOwnerFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeOwnerFunction, cancellationToken);
        }

        public Task<string> RemoveOwnerRequestAsync(string prevOwner, string owner, BigInteger threshold)
        {
            var removeOwnerFunction = new RemoveOwnerFunction();
                removeOwnerFunction.PrevOwner = prevOwner;
                removeOwnerFunction.Owner = owner;
                removeOwnerFunction.Threshold = threshold;
            
             return ContractHandler.SendRequestAsync(removeOwnerFunction);
        }

        public Task<TransactionReceipt> RemoveOwnerRequestAndWaitForReceiptAsync(string prevOwner, string owner, BigInteger threshold, CancellationToken cancellationToken = default(CancellationToken))
        {
            var removeOwnerFunction = new RemoveOwnerFunction();
                removeOwnerFunction.PrevOwner = prevOwner;
                removeOwnerFunction.Owner = owner;
                removeOwnerFunction.Threshold = threshold;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeOwnerFunction, cancellationToken);
        }

        public Task<string> RequiredTxGasRequestAsync(RequiredTxGasFunction requiredTxGasFunction)
        {
             return ContractHandler.SendRequestAsync(requiredTxGasFunction);
        }

        public Task<TransactionReceipt> RequiredTxGasRequestAndWaitForReceiptAsync(RequiredTxGasFunction requiredTxGasFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(requiredTxGasFunction, cancellationToken);
        }

        public Task<string> RequiredTxGasRequestAsync(string to, BigInteger value, byte[] data, byte operation)
        {
            var requiredTxGasFunction = new RequiredTxGasFunction();
                requiredTxGasFunction.To = to;
                requiredTxGasFunction.Value = value;
                requiredTxGasFunction.Data = data;
                requiredTxGasFunction.Operation = operation;
            
             return ContractHandler.SendRequestAsync(requiredTxGasFunction);
        }

        public Task<TransactionReceipt> RequiredTxGasRequestAndWaitForReceiptAsync(string to, BigInteger value, byte[] data, byte operation, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requiredTxGasFunction = new RequiredTxGasFunction();
                requiredTxGasFunction.To = to;
                requiredTxGasFunction.Value = value;
                requiredTxGasFunction.Data = data;
                requiredTxGasFunction.Operation = operation;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(requiredTxGasFunction, cancellationToken);
        }

        public Task<string> SetFallbackHandlerRequestAsync(SetFallbackHandlerFunction setFallbackHandlerFunction)
        {
             return ContractHandler.SendRequestAsync(setFallbackHandlerFunction);
        }

        public Task<TransactionReceipt> SetFallbackHandlerRequestAndWaitForReceiptAsync(SetFallbackHandlerFunction setFallbackHandlerFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFallbackHandlerFunction, cancellationToken);
        }

        public Task<string> SetFallbackHandlerRequestAsync(string handler)
        {
            var setFallbackHandlerFunction = new SetFallbackHandlerFunction();
                setFallbackHandlerFunction.Handler = handler;
            
             return ContractHandler.SendRequestAsync(setFallbackHandlerFunction);
        }

        public Task<TransactionReceipt> SetFallbackHandlerRequestAndWaitForReceiptAsync(string handler, CancellationToken cancellationToken = default(CancellationToken))
        {
            var setFallbackHandlerFunction = new SetFallbackHandlerFunction();
                setFallbackHandlerFunction.Handler = handler;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFallbackHandlerFunction, cancellationToken);
        }

        public Task<string> SetGuardRequestAsync(SetGuardFunction setGuardFunction)
        {
             return ContractHandler.SendRequestAsync(setGuardFunction);
        }

        public Task<TransactionReceipt> SetGuardRequestAndWaitForReceiptAsync(SetGuardFunction setGuardFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setGuardFunction, cancellationToken);
        }

        public Task<string> SetGuardRequestAsync(string guard)
        {
            var setGuardFunction = new SetGuardFunction();
                setGuardFunction.Guard = guard;
            
             return ContractHandler.SendRequestAsync(setGuardFunction);
        }

        public Task<TransactionReceipt> SetGuardRequestAndWaitForReceiptAsync(string guard, CancellationToken cancellationToken = default(CancellationToken))
        {
            var setGuardFunction = new SetGuardFunction();
                setGuardFunction.Guard = guard;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setGuardFunction, cancellationToken);
        }

        public Task<string> SetupRequestAsync(SetupFunction setupFunction)
        {
             return ContractHandler.SendRequestAsync(setupFunction);
        }

        public Task<TransactionReceipt> SetupRequestAndWaitForReceiptAsync(SetupFunction setupFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setupFunction, cancellationToken);
        }

        public Task<string> SetupRequestAsync(List<string> owners, BigInteger threshold, string to, byte[] data, string fallbackHandler, string paymentToken, BigInteger payment, string paymentReceiver)
        {
            var setupFunction = new SetupFunction();
                setupFunction.Owners = owners;
                setupFunction.Threshold = threshold;
                setupFunction.To = to;
                setupFunction.Data = data;
                setupFunction.FallbackHandler = fallbackHandler;
                setupFunction.PaymentToken = paymentToken;
                setupFunction.Payment = payment;
                setupFunction.PaymentReceiver = paymentReceiver;
            
             return ContractHandler.SendRequestAsync(setupFunction);
        }

        public Task<TransactionReceipt> SetupRequestAndWaitForReceiptAsync(List<string> owners, BigInteger threshold, string to, byte[] data, string fallbackHandler, string paymentToken, BigInteger payment, string paymentReceiver, CancellationToken cancellationToken = default(CancellationToken))
        {
            var setupFunction = new SetupFunction();
                setupFunction.Owners = owners;
                setupFunction.Threshold = threshold;
                setupFunction.To = to;
                setupFunction.Data = data;
                setupFunction.FallbackHandler = fallbackHandler;
                setupFunction.PaymentToken = paymentToken;
                setupFunction.Payment = payment;
                setupFunction.PaymentReceiver = paymentReceiver;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setupFunction, cancellationToken);
        }

        public Task<BigInteger> SignedMessagesQueryAsync(SignedMessagesFunction signedMessagesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SignedMessagesFunction, BigInteger>(signedMessagesFunction, blockParameter);
        }

        
        public Task<BigInteger> SignedMessagesQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var signedMessagesFunction = new SignedMessagesFunction();
                signedMessagesFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<SignedMessagesFunction, BigInteger>(signedMessagesFunction, blockParameter);
        }

        public Task<string> SimulateAndRevertRequestAsync(SimulateAndRevertFunction simulateAndRevertFunction)
        {
             return ContractHandler.SendRequestAsync(simulateAndRevertFunction);
        }

        public Task<TransactionReceipt> SimulateAndRevertRequestAndWaitForReceiptAsync(SimulateAndRevertFunction simulateAndRevertFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(simulateAndRevertFunction, cancellationToken);
        }

        public Task<string> SimulateAndRevertRequestAsync(string targetContract, byte[] calldataPayload)
        {
            var simulateAndRevertFunction = new SimulateAndRevertFunction();
                simulateAndRevertFunction.TargetContract = targetContract;
                simulateAndRevertFunction.CalldataPayload = calldataPayload;
            
             return ContractHandler.SendRequestAsync(simulateAndRevertFunction);
        }

        public Task<TransactionReceipt> SimulateAndRevertRequestAndWaitForReceiptAsync(string targetContract, byte[] calldataPayload, CancellationToken cancellationToken = default(CancellationToken))
        {
            var simulateAndRevertFunction = new SimulateAndRevertFunction();
                simulateAndRevertFunction.TargetContract = targetContract;
                simulateAndRevertFunction.CalldataPayload = calldataPayload;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(simulateAndRevertFunction, cancellationToken);
        }

        public Task<string> SwapOwnerRequestAsync(SwapOwnerFunction swapOwnerFunction)
        {
             return ContractHandler.SendRequestAsync(swapOwnerFunction);
        }

        public Task<TransactionReceipt> SwapOwnerRequestAndWaitForReceiptAsync(SwapOwnerFunction swapOwnerFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(swapOwnerFunction, cancellationToken);
        }

        public Task<string> SwapOwnerRequestAsync(string prevOwner, string oldOwner, string newOwner)
        {
            var swapOwnerFunction = new SwapOwnerFunction();
                swapOwnerFunction.PrevOwner = prevOwner;
                swapOwnerFunction.OldOwner = oldOwner;
                swapOwnerFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(swapOwnerFunction);
        }

        public Task<TransactionReceipt> SwapOwnerRequestAndWaitForReceiptAsync(string prevOwner, string oldOwner, string newOwner, CancellationToken cancellationToken = default(CancellationToken))
        {
            var swapOwnerFunction = new SwapOwnerFunction();
                swapOwnerFunction.PrevOwner = prevOwner;
                swapOwnerFunction.OldOwner = oldOwner;
                swapOwnerFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(swapOwnerFunction, cancellationToken);
        }
    }
}
