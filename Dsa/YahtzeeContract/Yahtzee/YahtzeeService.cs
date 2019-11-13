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

        public Task<bool> PartnerJoinedQueryAsync(PartnerJoinedFunction partnerJoinedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerJoinedFunction, bool>(partnerJoinedFunction, blockParameter);
        }

        
        public Task<bool> PartnerJoinedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerJoinedFunction, bool>(null, blockParameter);
        }

        public Task<string> AbortGameRequestAsync(AbortGameFunction abortGameFunction)
        {
             return ContractHandler.SendRequestAsync(abortGameFunction);
        }

        public Task<string> AbortGameRequestAsync()
        {
             return ContractHandler.SendRequestAsync<AbortGameFunction>();
        }

        public Task<TransactionReceipt> AbortGameRequestAndWaitForReceiptAsync(AbortGameFunction abortGameFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(abortGameFunction, cancellationToken);
        }

        public Task<TransactionReceipt> AbortGameRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<AbortGameFunction>(null, cancellationToken);
        }

        public Task<BigInteger> StakeQueryAsync(StakeFunction stakeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StakeFunction, BigInteger>(stakeFunction, blockParameter);
        }

        
        public Task<BigInteger> StakeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StakeFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> PartnerQueryAsync(PartnerFunction partnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerFunction, string>(partnerFunction, blockParameter);
        }

        
        public Task<string> PartnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerFunction, string>(null, blockParameter);
        }

        public Task<string> JoinGameRequestAsync(JoinGameFunction joinGameFunction)
        {
             return ContractHandler.SendRequestAsync(joinGameFunction);
        }

        public Task<TransactionReceipt> JoinGameRequestAndWaitForReceiptAsync(JoinGameFunction joinGameFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(joinGameFunction, cancellationToken);
        }

        public Task<string> JoinGameRequestAsync(BigInteger stake)
        {
            var joinGameFunction = new JoinGameFunction();
                joinGameFunction.Stake = stake;
            
             return ContractHandler.SendRequestAsync(joinGameFunction);
        }

        public Task<TransactionReceipt> JoinGameRequestAndWaitForReceiptAsync(BigInteger stake, CancellationTokenSource cancellationToken = null)
        {
            var joinGameFunction = new JoinGameFunction();
                joinGameFunction.Stake = stake;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(joinGameFunction, cancellationToken);
        }
    }
}
