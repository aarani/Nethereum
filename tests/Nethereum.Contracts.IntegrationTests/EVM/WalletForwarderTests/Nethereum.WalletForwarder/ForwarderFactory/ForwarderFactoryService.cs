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
using Nethereum.WalletForwarder.Contracts.ForwarderFactory.ContractDefinition;

namespace Nethereum.WalletForwarder.Contracts.ForwarderFactory
{
    public partial class ForwarderFactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ForwarderFactoryDeployment forwarderFactoryDeployment, CancellationToken cancellationToken = default(CancellationToken))
        {
            return web3.Eth.GetContractDeploymentHandler<ForwarderFactoryDeployment>().SendRequestAndWaitForReceiptAsync(forwarderFactoryDeployment, cancellationToken);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ForwarderFactoryDeployment forwarderFactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ForwarderFactoryDeployment>().SendRequestAsync(forwarderFactoryDeployment);
        }

        public static async Task<ForwarderFactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ForwarderFactoryDeployment forwarderFactoryDeployment, CancellationToken cancellationToken = default(CancellationToken))
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, forwarderFactoryDeployment, cancellationToken);
            return new ForwarderFactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ForwarderFactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CloneForwarderRequestAsync(CloneForwarderFunction cloneForwarderFunction)
        {
             return ContractHandler.SendRequestAsync(cloneForwarderFunction);
        }

        public Task<TransactionReceipt> CloneForwarderRequestAndWaitForReceiptAsync(CloneForwarderFunction cloneForwarderFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cloneForwarderFunction, cancellationToken);
        }

        public Task<string> CloneForwarderRequestAsync(string forwarder, BigInteger salt)
        {
            var cloneForwarderFunction = new CloneForwarderFunction();
                cloneForwarderFunction.Forwarder = forwarder;
                cloneForwarderFunction.Salt = salt;
            
             return ContractHandler.SendRequestAsync(cloneForwarderFunction);
        }

        public Task<TransactionReceipt> CloneForwarderRequestAndWaitForReceiptAsync(string forwarder, BigInteger salt, CancellationToken cancellationToken = default(CancellationToken))
        {
            var cloneForwarderFunction = new CloneForwarderFunction();
                cloneForwarderFunction.Forwarder = forwarder;
                cloneForwarderFunction.Salt = salt;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cloneForwarderFunction, cancellationToken);
        }

        public Task<string> FlushEtherRequestAsync(FlushEtherFunction flushEtherFunction)
        {
             return ContractHandler.SendRequestAsync(flushEtherFunction);
        }

        public Task<TransactionReceipt> FlushEtherRequestAndWaitForReceiptAsync(FlushEtherFunction flushEtherFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(flushEtherFunction, cancellationToken);
        }

        public Task<string> FlushEtherRequestAsync(List<string> forwarders)
        {
            var flushEtherFunction = new FlushEtherFunction();
                flushEtherFunction.Forwarders = forwarders;
            
             return ContractHandler.SendRequestAsync(flushEtherFunction);
        }

        public Task<TransactionReceipt> FlushEtherRequestAndWaitForReceiptAsync(List<string> forwarders, CancellationToken cancellationToken = default(CancellationToken))
        {
            var flushEtherFunction = new FlushEtherFunction();
                flushEtherFunction.Forwarders = forwarders;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(flushEtherFunction, cancellationToken);
        }

        public Task<string> FlushTokensRequestAsync(FlushTokensFunction flushTokensFunction)
        {
             return ContractHandler.SendRequestAsync(flushTokensFunction);
        }

        public Task<TransactionReceipt> FlushTokensRequestAndWaitForReceiptAsync(FlushTokensFunction flushTokensFunction, CancellationToken cancellationToken = default(CancellationToken))
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(flushTokensFunction, cancellationToken);
        }

        public Task<string> FlushTokensRequestAsync(List<string> forwarders, string tokenAddres)
        {
            var flushTokensFunction = new FlushTokensFunction();
                flushTokensFunction.Forwarders = forwarders;
                flushTokensFunction.TokenAddres = tokenAddres;
            
             return ContractHandler.SendRequestAsync(flushTokensFunction);
        }

        public Task<TransactionReceipt> FlushTokensRequestAndWaitForReceiptAsync(List<string> forwarders, string tokenAddres, CancellationToken cancellationToken = default(CancellationToken))
        {
            var flushTokensFunction = new FlushTokensFunction();
                flushTokensFunction.Forwarders = forwarders;
                flushTokensFunction.TokenAddres = tokenAddres;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(flushTokensFunction, cancellationToken);
        }
    }
}
