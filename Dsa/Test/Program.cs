using System;
using System.Threading;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Model;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.TransactionManagers;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using Account = Nethereum.Web3.Accounts.Account;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var privateAddress = "0x45a0f6233B9fA641ee2FefA0f567d66376FDA0fe";
            var url = "https://rinkeby.infura.io/v3/11f60370f16f4db397a95e796caa9009";
            //var web3 = new Web3(url);
            //var balance = await web3.Eth.GetBalance.SendRequestAsync("0xde0b295669a9fd93d5f28d9ec85e40f4cb697bae");
            //Console.Out.WriteLine($"Eth: {Web3.Convert.FromWei(balance)}");
            //var networkId = await web3.Net.Version.SendRequestAsync();
            //Console.Out.WriteLine($"Network: {networkId}");


            //var latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            //var latestBlock = await web3.Eth.Blocks.GetBlockWithTransactionsHashesByNumber.SendRequestAsync(latestBlockNumber);


            var privateKey = Settings.Settings.PrivateKey;
            var account = new Account(privateKey);
            var web3 = new Web3(account,url);

            var _1wei = new HexBigInteger(1);
            var _1eth = new HexBigInteger(1000000000000000000);
            var _0_1eth = new HexBigInteger(100000000000000000);
            var toAddress = "0xde0b295669a9fd93d5f28d9ec85e40f4cb697bae";
            var transaction = await web3.TransactionManager.SendTransactionAsync(account.Address, toAddress, new HexBigInteger(_1wei));
            //var finishedTransaction = await web3.TransactionManager.SendTransactionAndWaitForReceiptAsync(
            //    new TransactionInput(account.Address, toAddress, new HexBigInteger(_1wei)), new CancellationTokenSource());
            //var unlock = await web3.Personal.UnlockAccount.SendRequestAsync(privateAddress, privateKey, 10);
            var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync("0x26f5001289912f0e53fbc425f0a068cf9f5669c9a16494d90e99050553c2a9d3");
            var receiptForTransaction = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transaction);
            //https://docs.nethereum.com/en/latest/Nethereum.Workbooks/docs/nethereum-gettingstarted-smartcontracts-untyped/#deploying-smart-contracts
            //var teset = web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(abi,)
            //web3.Personal.SignAndSendTransaction()

            int x = 0;
        }
    }
}
