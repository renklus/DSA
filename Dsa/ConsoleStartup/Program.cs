using System;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using TestNethereum.SimpleStorage;
using TestNethereum.SimpleStorage.ContractDefinition;

namespace ConsoleStartup
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo().Wait();
        }

        static async Task Demo()
        {
            try
            {
                // Setup
                // Using local chain eg Geth https://github.com/Nethereum/TestChains#geth

                //Using Infura: 
                //var url = "http://rinkeby.infura.io/v3/11f60370f16f4db397a95e796caa9009";
                //var privateKey = "92bb42f449564cc2ac53576951dc9fb4";
                //var account = new Account(privateKey);
                //var web3 = new Web3(account, url);
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


                var privateAddress = "0x45a0f6233B9fA641ee2FefA0f567d66376FDA0fe";
                var url = "https://rinkeby.infura.io/v3/11f60370f16f4db397a95e796caa9009";
                var privateKey = Settings.Settings.PrivateKey;
                var account = new Account(privateKey);
                var web3 = new Web3(account, url);

                Console.WriteLine("Deploying...");
                var deployment = new SimpleStorageDeployment();
                var receipt = await SimpleStorageService.DeployContractAndWaitForReceiptAsync(web3, deployment);
                var service = new SimpleStorageService(web3, receipt.ContractAddress);
                Console.WriteLine($"Contract Deployment Tx Status: {receipt.Status.Value}");
                Console.WriteLine($"Contract Address: {service.ContractHandler.ContractAddress}");
                Console.WriteLine("");

                Console.WriteLine("Sending a transaction to the function set()...");
                var receiptForSetFunctionCall = await service.SetRequestAndWaitForReceiptAsync(
                    new SetFunction() { X = 42 });
                Console.WriteLine($"Finished storing an int: Tx Hash: {receiptForSetFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished storing an int: Tx Status: {receiptForSetFunctionCall.Status.Value}");
                Console.WriteLine("");

                Console.WriteLine("Calling the function get()...");
                var intValueFromGetFunctionCall = await service.GetQueryAsync();
                Console.WriteLine($"Int value: {intValueFromGetFunctionCall} (expecting value 42)");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
