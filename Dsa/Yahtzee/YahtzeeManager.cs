using System;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using YahtzeeContract.Yahtzee;
using YahtzeeContract.Yahtzee.ContractDefinition;

namespace Yahtzee
{
    public class YahtzeeManager
    {
        private string privateAddress = Settings.Settings.PrivateAddress;
        private string url = Settings.Settings.Web3Url;
        private string privateKey = Settings.Settings.PrivateKey;

        public YahtzeeManager()
        {

        }

        public async Task DeployContract()
        {
            Account account = new Account(privateKey);
            Web3 web3 = new Web3(account, url);

            var deployment = new YahtzeeDeployment();
            var receipt = await YahtzeeService.DeployContractAndWaitForReceiptAsync(web3, deployment);
            var service = new YahtzeeService(web3, receipt.ContractAddress);

        }
    }
}
