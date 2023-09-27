using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Nethereum.ENS.ShortNameClaims.ContractDefinition;

namespace Nethereum.ENS
{
    public partial class ShortNameClaimsService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ShortNameClaimsDeployment shortNameClaimsDeployment, CancellationToken cancellationToken = default(CancellationToken))
        {
            return web3.Eth.GetContractDeploymentHandler<ShortNameClaimsDeployment>().SendRequestAndWaitForReceiptAsync(shortNameClaimsDeployment, cancellationToken);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ShortNameClaimsDeployment shortNameClaimsDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ShortNameClaimsDeployment>().SendRequestAsync(shortNameClaimsDeployment);
        }

        public static async Task<ShortNameClaimsService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ShortNameClaimsDeployment shortNameClaimsDeployment, CancellationToken cancellationToken = default(CancellationToken))
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, shortNameClaimsDeployment, cancellationToken).ConfigureAwait(false);
            return new ShortNameClaimsService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ShortNameClaimsService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> RemoveOwnerRequestAsync(RemoveOwnerFunction removeOwnerFunction)
        {
             return ContractHandler.SendRequestAsync(removeOwnerFunction);
        }

        public Task<TransactionReceipt> RemoveOwnerRequestAndWaitForReceiptAsync(RemoveOwnerFunction removeOwnerFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeOwnerFunction, cancellationToken);
        }

        public Task<string> RemoveOwnerRequestAsync(string owner)
        {
            var removeOwnerFunction = new RemoveOwnerFunction();
                removeOwnerFunction.Owner = owner;
            
             return ContractHandler.SendRequestAsync(removeOwnerFunction);
        }

        public Task<TransactionReceipt> RemoveOwnerRequestAndWaitForReceiptAsync(string owner, CancellationToken cancellationToken = default(CancellationToken))
        {
            var removeOwnerFunction = new RemoveOwnerFunction();
                removeOwnerFunction.Owner = owner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeOwnerFunction, cancellationToken);
        }

        public Task<string> PriceOracleQueryAsync(PriceOracleFunction priceOracleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceOracleFunction, string>(priceOracleFunction, blockParameter);
        }

        
        public Task<string> PriceOracleQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceOracleFunction, string>(null, blockParameter);
        }

        public Task<string> RegistrarQueryAsync(RegistrarFunction registrarFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RegistrarFunction, string>(registrarFunction, blockParameter);
        }

        
        public Task<string> RegistrarQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RegistrarFunction, string>(null, blockParameter);
        }

        public Task<string> RemoveRatifierRequestAsync(RemoveRatifierFunction removeRatifierFunction)
        {
             return ContractHandler.SendRequestAsync(removeRatifierFunction);
        }

        public Task<TransactionReceipt> RemoveRatifierRequestAndWaitForReceiptAsync(RemoveRatifierFunction removeRatifierFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeRatifierFunction, cancellationToken);
        }

        public Task<string> RemoveRatifierRequestAsync(string ratifier)
        {
            var removeRatifierFunction = new RemoveRatifierFunction();
                removeRatifierFunction.Ratifier = ratifier;
            
             return ContractHandler.SendRequestAsync(removeRatifierFunction);
        }

        public Task<TransactionReceipt> RemoveRatifierRequestAndWaitForReceiptAsync(string ratifier, CancellationToken cancellationToken = default(CancellationToken))
        {
            var removeRatifierFunction = new RemoveRatifierFunction();
                removeRatifierFunction.Ratifier = ratifier;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeRatifierFunction, cancellationToken);
        }

        public Task<BigInteger> PendingClaimsQueryAsync(PendingClaimsFunction pendingClaimsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingClaimsFunction, BigInteger>(pendingClaimsFunction, blockParameter);
        }

        
        public Task<BigInteger> PendingClaimsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingClaimsFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> AddRatifierRequestAsync(AddRatifierFunction addRatifierFunction)
        {
             return ContractHandler.SendRequestAsync(addRatifierFunction);
        }

        public Task<TransactionReceipt> AddRatifierRequestAndWaitForReceiptAsync(AddRatifierFunction addRatifierFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addRatifierFunction, cancellationToken);
        }

        public Task<string> AddRatifierRequestAsync(string ratifier)
        {
            var addRatifierFunction = new AddRatifierFunction();
                addRatifierFunction.Ratifier = ratifier;
            
             return ContractHandler.SendRequestAsync(addRatifierFunction);
        }

        public Task<TransactionReceipt> AddRatifierRequestAndWaitForReceiptAsync(string ratifier, CancellationToken cancellationToken = default(CancellationToken))
        {
            var addRatifierFunction = new AddRatifierFunction();
                addRatifierFunction.Ratifier = ratifier;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addRatifierFunction, cancellationToken);
        }

        public Task<string> SubmitPrefixClaimRequestAsync(SubmitPrefixClaimFunction submitPrefixClaimFunction)
        {
             return ContractHandler.SendRequestAsync(submitPrefixClaimFunction);
        }

        public Task<TransactionReceipt> SubmitPrefixClaimRequestAndWaitForReceiptAsync(SubmitPrefixClaimFunction submitPrefixClaimFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitPrefixClaimFunction, cancellationToken);
        }

        public Task<string> SubmitPrefixClaimRequestAsync(byte[] name, string claimant, string email)
        {
            var submitPrefixClaimFunction = new SubmitPrefixClaimFunction();
                submitPrefixClaimFunction.Name = name;
                submitPrefixClaimFunction.Claimant = claimant;
                submitPrefixClaimFunction.Email = email;
            
             return ContractHandler.SendRequestAsync(submitPrefixClaimFunction);
        }

        public Task<TransactionReceipt> SubmitPrefixClaimRequestAndWaitForReceiptAsync(byte[] name, string claimant, string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            var submitPrefixClaimFunction = new SubmitPrefixClaimFunction();
                submitPrefixClaimFunction.Name = name;
                submitPrefixClaimFunction.Claimant = claimant;
                submitPrefixClaimFunction.Email = email;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitPrefixClaimFunction, cancellationToken);
        }

        public Task<BigInteger> UnresolvedClaimsQueryAsync(UnresolvedClaimsFunction unresolvedClaimsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UnresolvedClaimsFunction, BigInteger>(unresolvedClaimsFunction, blockParameter);
        }

        
        public Task<BigInteger> UnresolvedClaimsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UnresolvedClaimsFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetClaimCostQueryAsync(GetClaimCostFunction getClaimCostFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetClaimCostFunction, BigInteger>(getClaimCostFunction, blockParameter);
        }

        
        public Task<BigInteger> GetClaimCostQueryAsync(string claimed, BlockParameter blockParameter = null)
        {
            var getClaimCostFunction = new GetClaimCostFunction();
                getClaimCostFunction.Claimed = claimed;
            
            return ContractHandler.QueryAsync<GetClaimCostFunction, BigInteger>(getClaimCostFunction, blockParameter);
        }

        public Task<string> AddOwnerRequestAsync(AddOwnerFunction addOwnerFunction)
        {
             return ContractHandler.SendRequestAsync(addOwnerFunction);
        }

        public Task<TransactionReceipt> AddOwnerRequestAndWaitForReceiptAsync(AddOwnerFunction addOwnerFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addOwnerFunction, cancellationToken);
        }

        public Task<string> AddOwnerRequestAsync(string owner)
        {
            var addOwnerFunction = new AddOwnerFunction();
                addOwnerFunction.Owner = owner;
            
             return ContractHandler.SendRequestAsync(addOwnerFunction);
        }

        public Task<TransactionReceipt> AddOwnerRequestAndWaitForReceiptAsync(string owner, CancellationToken cancellationToken = default(CancellationToken))
        {
            var addOwnerFunction = new AddOwnerFunction();
                addOwnerFunction.Owner = owner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addOwnerFunction, cancellationToken);
        }

        public Task<string> WithdrawClaimRequestAsync(WithdrawClaimFunction withdrawClaimFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawClaimFunction);
        }

        public Task<TransactionReceipt> WithdrawClaimRequestAndWaitForReceiptAsync(WithdrawClaimFunction withdrawClaimFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawClaimFunction, cancellationToken);
        }

        public Task<string> WithdrawClaimRequestAsync(byte[] claimId)
        {
            var withdrawClaimFunction = new WithdrawClaimFunction();
                withdrawClaimFunction.ClaimId = claimId;
            
             return ContractHandler.SendRequestAsync(withdrawClaimFunction);
        }

        public Task<TransactionReceipt> WithdrawClaimRequestAndWaitForReceiptAsync(byte[] claimId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var withdrawClaimFunction = new WithdrawClaimFunction();
                withdrawClaimFunction.ClaimId = claimId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawClaimFunction, cancellationToken);
        }

        public Task<string> DestroyRequestAsync(DestroyFunction destroyFunction)
        {
             return ContractHandler.SendRequestAsync(destroyFunction);
        }

        public Task<string> DestroyRequestAsync()
        {
             return ContractHandler.SendRequestAsync<DestroyFunction>();
        }

        public Task<TransactionReceipt> DestroyRequestAndWaitForReceiptAsync(DestroyFunction destroyFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(destroyFunction, cancellationToken);
        }

        public Task<TransactionReceipt> DestroyRequestAndWaitForReceiptAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<DestroyFunction>(null, cancellationToken);
        }

        public Task<string> RatifyClaimsRequestAsync(RatifyClaimsFunction ratifyClaimsFunction)
        {
             return ContractHandler.SendRequestAsync(ratifyClaimsFunction);
        }

        public Task<string> RatifyClaimsRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RatifyClaimsFunction>();
        }

        public Task<TransactionReceipt> RatifyClaimsRequestAndWaitForReceiptAsync(RatifyClaimsFunction ratifyClaimsFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ratifyClaimsFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RatifyClaimsRequestAndWaitForReceiptAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RatifyClaimsFunction>(null, cancellationToken);
        }

        public Task<byte[]> ComputeClaimIdQueryAsync(ComputeClaimIdFunction computeClaimIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ComputeClaimIdFunction, byte[]>(computeClaimIdFunction, blockParameter);
        }

        
        public Task<byte[]> ComputeClaimIdQueryAsync(string claimed, byte[] dnsname, string claimant, string email, BlockParameter blockParameter = null)
        {
            var computeClaimIdFunction = new ComputeClaimIdFunction();
                computeClaimIdFunction.Claimed = claimed;
                computeClaimIdFunction.Dnsname = dnsname;
                computeClaimIdFunction.Claimant = claimant;
                computeClaimIdFunction.Email = email;
            
            return ContractHandler.QueryAsync<ComputeClaimIdFunction, byte[]>(computeClaimIdFunction, blockParameter);
        }

        public Task<string> SetClaimStatusRequestAsync(SetClaimStatusFunction setClaimStatusFunction)
        {
             return ContractHandler.SendRequestAsync(setClaimStatusFunction);
        }

        public Task<TransactionReceipt> SetClaimStatusRequestAndWaitForReceiptAsync(SetClaimStatusFunction setClaimStatusFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setClaimStatusFunction, cancellationToken);
        }

        public Task<string> SetClaimStatusRequestAsync(byte[] claimId, bool approved)
        {
            var setClaimStatusFunction = new SetClaimStatusFunction();
                setClaimStatusFunction.ClaimId = claimId;
                setClaimStatusFunction.Approved = approved;
            
             return ContractHandler.SendRequestAsync(setClaimStatusFunction);
        }

        public Task<TransactionReceipt> SetClaimStatusRequestAndWaitForReceiptAsync(byte[] claimId, bool approved, CancellationToken cancellationToken = default(CancellationToken))
        {
            var setClaimStatusFunction = new SetClaimStatusFunction();
                setClaimStatusFunction.ClaimId = claimId;
                setClaimStatusFunction.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setClaimStatusFunction, cancellationToken);
        }

        public Task<string> SubmitExactClaimRequestAsync(SubmitExactClaimFunction submitExactClaimFunction)
        {
             return ContractHandler.SendRequestAsync(submitExactClaimFunction);
        }

        public Task<TransactionReceipt> SubmitExactClaimRequestAndWaitForReceiptAsync(SubmitExactClaimFunction submitExactClaimFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitExactClaimFunction, cancellationToken);
        }

        public Task<string> SubmitExactClaimRequestAsync(byte[] name, string claimant, string email)
        {
            var submitExactClaimFunction = new SubmitExactClaimFunction();
                submitExactClaimFunction.Name = name;
                submitExactClaimFunction.Claimant = claimant;
                submitExactClaimFunction.Email = email;
            
             return ContractHandler.SendRequestAsync(submitExactClaimFunction);
        }

        public Task<TransactionReceipt> SubmitExactClaimRequestAndWaitForReceiptAsync(byte[] name, string claimant, string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            var submitExactClaimFunction = new SubmitExactClaimFunction();
                submitExactClaimFunction.Name = name;
                submitExactClaimFunction.Claimant = claimant;
                submitExactClaimFunction.Email = email;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitExactClaimFunction, cancellationToken);
        }

        public Task<byte> PhaseQueryAsync(PhaseFunction phaseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PhaseFunction, byte>(phaseFunction, blockParameter);
        }

        
        public Task<byte> PhaseQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PhaseFunction, byte>(null, blockParameter);
        }

        public Task<string> ResolveClaimRequestAsync(ResolveClaimFunction resolveClaimFunction)
        {
             return ContractHandler.SendRequestAsync(resolveClaimFunction);
        }

        public Task<TransactionReceipt> ResolveClaimRequestAndWaitForReceiptAsync(ResolveClaimFunction resolveClaimFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(resolveClaimFunction, cancellationToken);
        }

        public Task<string> ResolveClaimRequestAsync(byte[] claimId)
        {
            var resolveClaimFunction = new ResolveClaimFunction();
                resolveClaimFunction.ClaimId = claimId;
            
             return ContractHandler.SendRequestAsync(resolveClaimFunction);
        }

        public Task<TransactionReceipt> ResolveClaimRequestAndWaitForReceiptAsync(byte[] claimId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resolveClaimFunction = new ResolveClaimFunction();
                resolveClaimFunction.ClaimId = claimId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(resolveClaimFunction, cancellationToken);
        }

        public Task<string> SetClaimStatusesRequestAsync(SetClaimStatusesFunction setClaimStatusesFunction)
        {
             return ContractHandler.SendRequestAsync(setClaimStatusesFunction);
        }

        public Task<TransactionReceipt> SetClaimStatusesRequestAndWaitForReceiptAsync(SetClaimStatusesFunction setClaimStatusesFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setClaimStatusesFunction, cancellationToken);
        }

        public Task<string> SetClaimStatusesRequestAsync(List<byte[]> approved, List<byte[]> declined)
        {
            var setClaimStatusesFunction = new SetClaimStatusesFunction();
                setClaimStatusesFunction.Approved = approved;
                setClaimStatusesFunction.Declined = declined;
            
             return ContractHandler.SendRequestAsync(setClaimStatusesFunction);
        }

        public Task<TransactionReceipt> SetClaimStatusesRequestAndWaitForReceiptAsync(List<byte[]> approved, List<byte[]> declined, CancellationToken cancellationToken = default(CancellationToken))
        {
            var setClaimStatusesFunction = new SetClaimStatusesFunction();
                setClaimStatusesFunction.Approved = approved;
                setClaimStatusesFunction.Declined = declined;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setClaimStatusesFunction, cancellationToken);
        }

        public Task<string> CloseClaimsRequestAsync(CloseClaimsFunction closeClaimsFunction)
        {
             return ContractHandler.SendRequestAsync(closeClaimsFunction);
        }

        public Task<string> CloseClaimsRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CloseClaimsFunction>();
        }

        public Task<TransactionReceipt> CloseClaimsRequestAndWaitForReceiptAsync(CloseClaimsFunction closeClaimsFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(closeClaimsFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CloseClaimsRequestAndWaitForReceiptAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CloseClaimsFunction>(null, cancellationToken);
        }

        public Task<string> ResolveClaimsRequestAsync(ResolveClaimsFunction resolveClaimsFunction)
        {
             return ContractHandler.SendRequestAsync(resolveClaimsFunction);
        }

        public Task<TransactionReceipt> ResolveClaimsRequestAndWaitForReceiptAsync(ResolveClaimsFunction resolveClaimsFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(resolveClaimsFunction, cancellationToken);
        }

        public Task<string> ResolveClaimsRequestAsync(List<byte[]> claimIds)
        {
            var resolveClaimsFunction = new ResolveClaimsFunction();
                resolveClaimsFunction.ClaimIds = claimIds;
            
             return ContractHandler.SendRequestAsync(resolveClaimsFunction);
        }

        public Task<TransactionReceipt> ResolveClaimsRequestAndWaitForReceiptAsync(List<byte[]> claimIds, CancellationToken cancellationToken = default(CancellationToken))
        {
            var resolveClaimsFunction = new ResolveClaimsFunction();
                resolveClaimsFunction.ClaimIds = claimIds;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(resolveClaimsFunction, cancellationToken);
        }

        public Task<BigInteger> REGISTRATION_PERIODQueryAsync(REGISTRATION_PERIODFunction rEGISTRATION_PERIODFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<REGISTRATION_PERIODFunction, BigInteger>(rEGISTRATION_PERIODFunction, blockParameter);
        }

        
        public Task<BigInteger> REGISTRATION_PERIODQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<REGISTRATION_PERIODFunction, BigInteger>(null, blockParameter);
        }

        public Task<ClaimsOutputDTO> ClaimsQueryAsync(ClaimsFunction claimsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ClaimsFunction, ClaimsOutputDTO>(claimsFunction, blockParameter);
        }

        public Task<ClaimsOutputDTO> ClaimsQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var claimsFunction = new ClaimsFunction();
                claimsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ClaimsFunction, ClaimsOutputDTO>(claimsFunction, blockParameter);
        }

        public Task<string> SubmitCombinedClaimRequestAsync(SubmitCombinedClaimFunction submitCombinedClaimFunction)
        {
             return ContractHandler.SendRequestAsync(submitCombinedClaimFunction);
        }

        public Task<TransactionReceipt> SubmitCombinedClaimRequestAndWaitForReceiptAsync(SubmitCombinedClaimFunction submitCombinedClaimFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitCombinedClaimFunction, cancellationToken);
        }

        public Task<string> SubmitCombinedClaimRequestAsync(byte[] name, string claimant, string email)
        {
            var submitCombinedClaimFunction = new SubmitCombinedClaimFunction();
                submitCombinedClaimFunction.Name = name;
                submitCombinedClaimFunction.Claimant = claimant;
                submitCombinedClaimFunction.Email = email;
            
             return ContractHandler.SendRequestAsync(submitCombinedClaimFunction);
        }

        public Task<TransactionReceipt> SubmitCombinedClaimRequestAndWaitForReceiptAsync(byte[] name, string claimant, string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            var submitCombinedClaimFunction = new SubmitCombinedClaimFunction();
                submitCombinedClaimFunction.Name = name;
                submitCombinedClaimFunction.Claimant = claimant;
                submitCombinedClaimFunction.Email = email;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(submitCombinedClaimFunction, cancellationToken);
        }
    }
}
