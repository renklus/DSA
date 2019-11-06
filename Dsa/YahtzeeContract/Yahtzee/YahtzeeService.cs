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
using YahtzeeContract.Yahtzee.ContractDefinition;

namespace YahtzeeContract.Yahtzee
{
    public partial class YahtzeeService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, YahtzeeDeployment yahtzeeDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<YahtzeeDeployment>().SendRequestAndWaitForReceiptAsync(yahtzeeDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, YahtzeeDeployment yahtzeeDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<YahtzeeDeployment>().SendRequestAsync(yahtzeeDeployment);
        }

        public static async Task<YahtzeeService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, YahtzeeDeployment yahtzeeDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, yahtzeeDeployment, cancellationTokenSource);
            return new YahtzeeService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public YahtzeeService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> SetRequestAsync(SetFunction setFunction)
        {
             return ContractHandler.SendRequestAsync(setFunction);
        }

        public Task<TransactionReceipt> SetRequestAndWaitForReceiptAsync(SetFunction setFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFunction, cancellationToken);
        }

        public Task<string> SetRequestAsync(BigInteger x)
        {
            var setFunction = new SetFunction();
                setFunction.X = x;
            
             return ContractHandler.SendRequestAsync(setFunction);
        }

        public Task<TransactionReceipt> SetRequestAndWaitForReceiptAsync(BigInteger x, CancellationTokenSource cancellationToken = null)
        {
            var setFunction = new SetFunction();
                setFunction.X = x;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFunction, cancellationToken);
        }

        public Task<BigInteger> GetQueryAsync(GetFunction getFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetFunction, BigInteger>(getFunction, blockParameter);
        }

        
        public Task<BigInteger> GetQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetFunction, BigInteger>(null, blockParameter);
        }
    }
}
