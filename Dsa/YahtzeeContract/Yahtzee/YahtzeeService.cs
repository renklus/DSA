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

        public Task<string> ThrowFirstRequestAsync(ThrowFirstFunction throwFirstFunction)
        {
             return ContractHandler.SendRequestAsync(throwFirstFunction);
        }

        public Task<string> ThrowFirstRequestAsync()
        {
             return ContractHandler.SendRequestAsync<ThrowFirstFunction>();
        }

        public Task<TransactionReceipt> ThrowFirstRequestAndWaitForReceiptAsync(ThrowFirstFunction throwFirstFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(throwFirstFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ThrowFirstRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<ThrowFirstFunction>(null, cancellationToken);
        }

        public Task<bool> OwnerUsedScoringQueryAsync(OwnerUsedScoringFunction ownerUsedScoringFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerUsedScoringFunction, bool>(ownerUsedScoringFunction, blockParameter);
        }

        
        public Task<bool> OwnerUsedScoringQueryAsync(byte returnValue1, BlockParameter blockParameter = null)
        {
            var ownerUsedScoringFunction = new OwnerUsedScoringFunction();
                ownerUsedScoringFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<OwnerUsedScoringFunction, bool>(ownerUsedScoringFunction, blockParameter);
        }

        public Task<byte> ScoringOptionIndexQueryAsync(ScoringOptionIndexFunction scoringOptionIndexFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ScoringOptionIndexFunction, byte>(scoringOptionIndexFunction, blockParameter);
        }

        
        public Task<byte> ScoringOptionIndexQueryAsync(byte returnValue1, BlockParameter blockParameter = null)
        {
            var scoringOptionIndexFunction = new ScoringOptionIndexFunction();
                scoringOptionIndexFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<ScoringOptionIndexFunction, byte>(scoringOptionIndexFunction, blockParameter);
        }

        public Task<byte> OwnerDice2QueryAsync(OwnerDice2Function ownerDice2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDice2Function, byte>(ownerDice2Function, blockParameter);
        }

        
        public Task<byte> OwnerDice2QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDice2Function, byte>(null, blockParameter);
        }

        public Task<bool> PartnerJoinedQueryAsync(PartnerJoinedFunction partnerJoinedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerJoinedFunction, bool>(partnerJoinedFunction, blockParameter);
        }

        
        public Task<bool> PartnerJoinedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerJoinedFunction, bool>(null, blockParameter);
        }

        public Task<string> AssignResultRequestAsync(AssignResultFunction assignResultFunction)
        {
             return ContractHandler.SendRequestAsync(assignResultFunction);
        }

        public Task<TransactionReceipt> AssignResultRequestAndWaitForReceiptAsync(AssignResultFunction assignResultFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(assignResultFunction, cancellationToken);
        }

        public Task<string> AssignResultRequestAsync(byte scoringChoice)
        {
            var assignResultFunction = new AssignResultFunction();
                assignResultFunction.ScoringChoice = scoringChoice;
            
             return ContractHandler.SendRequestAsync(assignResultFunction);
        }

        public Task<TransactionReceipt> AssignResultRequestAndWaitForReceiptAsync(byte scoringChoice, CancellationTokenSource cancellationToken = null)
        {
            var assignResultFunction = new AssignResultFunction();
                assignResultFunction.ScoringChoice = scoringChoice;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(assignResultFunction, cancellationToken);
        }

        public Task<byte> OwnerDice5QueryAsync(OwnerDice5Function ownerDice5Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDice5Function, byte>(ownerDice5Function, blockParameter);
        }

        
        public Task<byte> OwnerDice5QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDice5Function, byte>(null, blockParameter);
        }

        public Task<byte> PartnerThrowsQueryAsync(PartnerThrowsFunction partnerThrowsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerThrowsFunction, byte>(partnerThrowsFunction, blockParameter);
        }

        
        public Task<byte> PartnerThrowsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerThrowsFunction, byte>(null, blockParameter);
        }

        public Task<byte> OwnerDice4QueryAsync(OwnerDice4Function ownerDice4Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDice4Function, byte>(ownerDice4Function, blockParameter);
        }

        
        public Task<byte> OwnerDice4QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDice4Function, byte>(null, blockParameter);
        }

        public Task<byte> PartnerDice2QueryAsync(PartnerDice2Function partnerDice2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerDice2Function, byte>(partnerDice2Function, blockParameter);
        }

        
        public Task<byte> PartnerDice2QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerDice2Function, byte>(null, blockParameter);
        }

        public Task<byte> PartnerDice1QueryAsync(PartnerDice1Function partnerDice1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerDice1Function, byte>(partnerDice1Function, blockParameter);
        }

        
        public Task<byte> PartnerDice1QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerDice1Function, byte>(null, blockParameter);
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

        public Task<byte> OwnerThrowsQueryAsync(OwnerThrowsFunction ownerThrowsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerThrowsFunction, byte>(ownerThrowsFunction, blockParameter);
        }

        
        public Task<byte> OwnerThrowsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerThrowsFunction, byte>(null, blockParameter);
        }

        public Task<string> ThrowLaterRequestAsync(ThrowLaterFunction throwLaterFunction)
        {
             return ContractHandler.SendRequestAsync(throwLaterFunction);
        }

        public Task<TransactionReceipt> ThrowLaterRequestAndWaitForReceiptAsync(ThrowLaterFunction throwLaterFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(throwLaterFunction, cancellationToken);
        }

        public Task<string> ThrowLaterRequestAsync(bool throwDice1, bool throwDice2, bool throwDice3, bool throwDice4, bool throwDice5)
        {
            var throwLaterFunction = new ThrowLaterFunction();
                throwLaterFunction.ThrowDice1 = throwDice1;
                throwLaterFunction.ThrowDice2 = throwDice2;
                throwLaterFunction.ThrowDice3 = throwDice3;
                throwLaterFunction.ThrowDice4 = throwDice4;
                throwLaterFunction.ThrowDice5 = throwDice5;
            
             return ContractHandler.SendRequestAsync(throwLaterFunction);
        }

        public Task<TransactionReceipt> ThrowLaterRequestAndWaitForReceiptAsync(bool throwDice1, bool throwDice2, bool throwDice3, bool throwDice4, bool throwDice5, CancellationTokenSource cancellationToken = null)
        {
            var throwLaterFunction = new ThrowLaterFunction();
                throwLaterFunction.ThrowDice1 = throwDice1;
                throwLaterFunction.ThrowDice2 = throwDice2;
                throwLaterFunction.ThrowDice3 = throwDice3;
                throwLaterFunction.ThrowDice4 = throwDice4;
                throwLaterFunction.ThrowDice5 = throwDice5;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(throwLaterFunction, cancellationToken);
        }

        public Task<byte> OwnerDice3QueryAsync(OwnerDice3Function ownerDice3Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDice3Function, byte>(ownerDice3Function, blockParameter);
        }

        
        public Task<byte> OwnerDice3QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDice3Function, byte>(null, blockParameter);
        }

        public Task<byte> RoundQueryAsync(RoundFunction roundFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RoundFunction, byte>(roundFunction, blockParameter);
        }

        
        public Task<byte> RoundQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RoundFunction, byte>(null, blockParameter);
        }

        public Task<byte> PartnerDice4QueryAsync(PartnerDice4Function partnerDice4Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerDice4Function, byte>(partnerDice4Function, blockParameter);
        }

        
        public Task<byte> PartnerDice4QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerDice4Function, byte>(null, blockParameter);
        }

        public Task<BigInteger> StakeQueryAsync(StakeFunction stakeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StakeFunction, BigInteger>(stakeFunction, blockParameter);
        }

        
        public Task<BigInteger> StakeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StakeFunction, BigInteger>(null, blockParameter);
        }

        public Task<byte> PartnerDice3QueryAsync(PartnerDice3Function partnerDice3Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerDice3Function, byte>(partnerDice3Function, blockParameter);
        }

        
        public Task<byte> PartnerDice3QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerDice3Function, byte>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<byte> PartnerDice5QueryAsync(PartnerDice5Function partnerDice5Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerDice5Function, byte>(partnerDice5Function, blockParameter);
        }

        
        public Task<byte> PartnerDice5QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerDice5Function, byte>(null, blockParameter);
        }

        public Task<bool> PartnerUsedScoringQueryAsync(PartnerUsedScoringFunction partnerUsedScoringFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerUsedScoringFunction, bool>(partnerUsedScoringFunction, blockParameter);
        }

        
        public Task<bool> PartnerUsedScoringQueryAsync(byte returnValue1, BlockParameter blockParameter = null)
        {
            var partnerUsedScoringFunction = new PartnerUsedScoringFunction();
                partnerUsedScoringFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<PartnerUsedScoringFunction, bool>(partnerUsedScoringFunction, blockParameter);
        }

        public Task<string> JoinGameRequestAsync(JoinGameFunction joinGameFunction)
        {
             return ContractHandler.SendRequestAsync(joinGameFunction);
        }

        public Task<string> JoinGameRequestAsync()
        {
             return ContractHandler.SendRequestAsync<JoinGameFunction>();
        }

        public Task<TransactionReceipt> JoinGameRequestAndWaitForReceiptAsync(JoinGameFunction joinGameFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(joinGameFunction, cancellationToken);
        }

        public Task<TransactionReceipt> JoinGameRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<JoinGameFunction>(null, cancellationToken);
        }

        public Task<string> PartnerQueryAsync(PartnerFunction partnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerFunction, string>(partnerFunction, blockParameter);
        }

        
        public Task<string> PartnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PartnerFunction, string>(null, blockParameter);
        }

        public Task<byte> OwnerDice1QueryAsync(OwnerDice1Function ownerDice1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDice1Function, byte>(ownerDice1Function, blockParameter);
        }

        
        public Task<byte> OwnerDice1QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDice1Function, byte>(null, blockParameter);
        }
    }
}
