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
        private string _privateAddress = Settings.Settings.PrivateAddress;
        private string _url = Settings.Settings.Web3Url;
        private string _privateKey = Settings.Settings.PrivateKey;
        private YahtzeeService _service;
        private byte _diceThrows = 0;

        public YahtzeeManager()
        {

        }

        public async Task DeployContract()
        {
            Account account = new Account(_privateKey);
            Web3 web3 = new Web3(account, _url);

            var deployment = new YahtzeeDeployment()
            {
                Partner = "0x08c31473a219f22922f47f001611d8bac62fbb6d",
                Stake = 20,
                AmountToSend = 20
            };
            var receipt = await YahtzeeService.DeployContractAndWaitForReceiptAsync(web3, deployment);
            _service = new YahtzeeService(web3, receipt.ContractAddress);

        }

        /// <summary>
        /// Würfelt die angegebenen Würfel und gibt die neuen Zahlen zurück
        /// Aufruf dieser Methode ist gemäss Yahtzee Regeln nur 3 mal möglich.
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> ThrowDice(bool dice1, bool dice2, bool dice3, bool dice4, bool dice5)
        {
            if (_diceThrows == 0)
            {
                if (!(dice1 && dice2 && dice3 && dice4 && dice5))
                    throw new ArgumentException($"Alle Würfel müssen beim ersten mal gewürfelt werden.");
                await _service.ThrowFirstRequestAndWaitForReceiptAsync();
            }
            else
                await _service.ThrowLaterRequestAndWaitForReceiptAsync(dice1, dice2, dice3, dice4, dice5);

            _diceThrows++;
            return await GetDice();
        }

        /// <summary>
        /// Gibt zuvor gewürfelte Zahlen zurück
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetDice()
        {
            var dices = new int[5];

            var queryResult = await _service.GetCurrentDicesQueryAsync();

            dices[0] = queryResult.ReturnValue1;
            dices[1] = queryResult.ReturnValue2;
            dices[2] = queryResult.ReturnValue3;
            dices[3] = queryResult.ReturnValue4;
            dices[4] = queryResult.ReturnValue5;

            return dices;
        }
    }
}
