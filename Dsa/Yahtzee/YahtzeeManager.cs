using System;
using System.Linq;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using YahtzeeContract.Yahtzee;
using YahtzeeContract.Yahtzee.ContractDefinition;

namespace Yahtzee
{
    public class YahtzeeManager
    {
        //private string _privateAddress = Settings.Settings.PrivateAddress;
        private string _url = Settings.Settings.Web3Url;
        private YahtzeeService _service;
        private byte _diceThrows = 0;
        private Web3 _web3;
        private bool _isGameStartedOrJoined = false;

        public YahtzeeManager(string privateKey)
        {
            Account account = new Account(privateKey);
            _web3 = new Web3(account, _url);
        }

        private async Task<string> DeployContractAsync(string partnerAddress)
        {
            var deployment = new YahtzeeDeployment()
            {
                Partner = partnerAddress,
                Stake = 20,
                AmountToSend = 20
            };
            var receipt = await YahtzeeService.DeployContractAndWaitForReceiptAsync(_web3, deployment);

            return receipt.ContractAddress;
        }

        /// <summary>
        /// Startet ein Spiel mit dem aktuell angemeldeten Spieler und dem angegebenen Partner
        /// </summary>
        /// <returns>Gibt die ID des Games zurück</returns>
        /// <param name="partnerAddress">z.B. "0x08c31473a219f22922f47f001611d8bac62fbb6d"</param>
        public async Task<string> StartGameAsync(string partnerAddress)
        {
            if (_isGameStartedOrJoined)
                throw new Exception("Game already started or joined.");
            _isGameStartedOrJoined = true;

            var contractId = await DeployContractAsync(partnerAddress);
            _service = new YahtzeeService(_web3, contractId);

            return contractId;
        }

        public async Task JoinGameAsync(string gameId)
        {
            if (_isGameStartedOrJoined)
                throw new Exception("Game already started or joined.");
            _isGameStartedOrJoined = true;

            _service = new YahtzeeService(_web3, gameId);

            await _service.JoinGameRequestAndWaitForReceiptAsync();
        }

        /// <summary>
        /// Würfelt die angegebenen Würfel und gibt die neuen Zahlen zurück
        /// Aufruf dieser Methode ist gemäss Yahtzee Regeln nur 3 mal möglich.
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> ThrowDiceAsync(bool dice1, bool dice2, bool dice3, bool dice4, bool dice5)
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
            return await GetDiceAsync();
        }

        public async Task<Game> ThrowDiceAndGetGameAsync(bool dice1, bool dice2, bool dice3, bool dice4, bool dice5)
        {
            var queryResult = await ThrowDiceAsync(dice1, dice2, dice3, dice4, dice5);
            var game = new Game() { Round = _diceThrows };
            for (int i = 0; i < 5; i++)
            {
                game.Dices[i].Value = queryResult[i];
            }

            return game;
        }

        public async Task ThrowDiceAndUpdateGameAsync(Game currentGameState, bool dice1, bool dice2, bool dice3, bool dice4, bool dice5)
        {
            if (currentGameState.Round != _diceThrows)
                throw new Exception("Dice throw counter out of sync");
            var queryResult = await ThrowDiceAsync(dice1, dice2, dice3, dice4, dice5);
            for (int i = 0; i < 5; i++)
            {
                currentGameState.Dices[i].Value = queryResult[i];
            }
            currentGameState.Round++;
        }

        /// <summary>
        /// Gibt zuvor gewürfelte Zahlen zurück
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetDiceAsync()
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

        public async Task<Game> GetGameStateAsync()
        {
            var dicesQuery = GetDiceAsync();
            var roundQuery = _service.RoundQueryAsync();
            var dicesQueryResult = await dicesQuery;
            var roundQueryResult = await roundQuery;

            var result = new Game() { Round = roundQueryResult };
            for (int i = 0; i < 5; i++)
            {
                result.Dices[i].Value = dicesQueryResult[i];
            }

            return result;
        }

        public async Task ScoreAsync(Score currentScore, Game currentGame, ScoreIndex scoreAs)
        {
            switch (scoreAs)
            {
                case ScoreIndex.Ones:
                    if (currentScore.Ones != 0)
                        throw new Exception();
                    break;
                case ScoreIndex.Twos:
                    if (currentScore.Twos != 0)
                        throw new Exception();
                    break;
                case ScoreIndex.Threes:
                    if (currentScore.Threes != 0)
                        throw new Exception();
                    break;
                case ScoreIndex.Fours:
                    if (currentScore.Fours != 0)
                        throw new Exception();
                    break;
                case ScoreIndex.Fives:
                    if (currentScore.Fives != 0)
                        throw new Exception();
                    break;
                case ScoreIndex.Sixes:
                    if (currentScore.Sixes != 0)
                        throw new Exception();
                    break;
                case ScoreIndex.ThreeOfAKind:
                    if (currentScore.ThreeOfAKind != 0)
                        throw new Exception();
                    break;
                case ScoreIndex.FourOfAKind:
                    if (currentScore.FourOfAKind != 0)
                        throw new Exception();
                    break;
                case ScoreIndex.FullHouse:
                    if (!currentScore.FullHouse)
                        throw new Exception();
                    break;
                case ScoreIndex.SmallStreet:
                    if (!currentScore.SmallStreet)
                        throw new Exception();
                    break;
                case ScoreIndex.LargeStreet:
                    if (!currentScore.LargeStreet)
                        throw new Exception();
                    break;
                case ScoreIndex.Yahtzee:
                    if (!currentScore.Yahtzee)
                        throw new Exception();
                    break;
                case ScoreIndex.Chance:
                    if (currentScore.Chance != 0)
                        throw new Exception();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(scoreAs), scoreAs, null);
            }

            byte scoreAsIndex = (byte)(scoreAs - 1);
            switch (scoreAs)
            {
                case ScoreIndex.Ones:
                    currentScore.Ones = currentGame.Dices.Sum(d => d.Value == 1 ? 1 : 0);
                    await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                        false,
                        false,
                        false,
                        false,
                        false);
                    break;
                case ScoreIndex.Twos:
                    currentScore.Twos = currentGame.Dices.Sum(d => d.Value == 2 ? 2 : 0);
                    await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                        false,
                        false,
                        false,
                        false,
                        false);
                    break;
                case ScoreIndex.Threes:
                    currentScore.Threes = currentGame.Dices.Sum(d => d.Value == 3 ? 3 : 0);
                    await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                        false,
                        false,
                        false,
                        false,
                        false);
                    break;
                case ScoreIndex.Fours:
                    currentScore.Fours = currentGame.Dices.Sum(d => d.Value == 4 ? 4 : 0);
                    await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                        false,
                        false,
                        false,
                        false,
                        false);
                    break;
                case ScoreIndex.Fives:
                    currentScore.Fives = currentGame.Dices.Sum(d => d.Value == 5 ? 5 : 0);
                    await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                        false,
                        false,
                        false,
                        false,
                        false);
                    break;
                case ScoreIndex.Sixes:
                    currentScore.Sixes = currentGame.Dices.Sum(d => d.Value == 6 ? 6 : 0);
                    await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                        false,
                        false,
                        false,
                        false,
                        false);
                    break;
                case ScoreIndex.ThreeOfAKind:
                    {
                        (int diceA, int diceB, int diceC) dices = (0, 0, 0);
                        currentScore.ThreeOfAKind = currentGame.Dices.Any(d =>
                            currentGame.Dices.Any(e => d.Number != e.Number &&
                                                       currentGame.Dices.Any(f =>
                                                       {
                                                           var solution = d.Number != f.Number &&
                                                                          d.Value == e.Value &&
                                                                          d.Value == f.Value;
                                                           if (solution)
                                                               dices = (d.Number, e.Number, f.Number);
                                                           return solution;
                                                       })
                            )
                        )
                            ? currentGame.Dices.Sum(d => d.Value)
                            : 0;
                        await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                            ContainsDiceNo(dices, 1),
                            ContainsDiceNo(dices, 2),
                            ContainsDiceNo(dices, 3),
                            ContainsDiceNo(dices, 4),
                            ContainsDiceNo(dices, 5));
                        break;
                    }
                case ScoreIndex.FourOfAKind:
                    {
                        (int diceA, int diceB, int diceC, int diceD) dices = (0, 0, 0, 0);
                        currentScore.FourOfAKind = currentGame.Dices.Any(d =>
                            currentGame.Dices.Any(e => d.Number != e.Number &&
                                                       currentGame.Dices.Any(f => d.Number != f.Number &&
                                                                                  currentGame.Dices.Any(g =>
                                                                                  {
                                                                                      var solution =
                                                                                          d.Number != g.Number &&
                                                                                          d.Value == e.Value &&
                                                                                          d.Value == f.Value &&
                                                                                          d.Value == g.Value;
                                                                                      if (solution)
                                                                                          dices = (d.Number, e.Number,
                                                                                              f.Number, g.Number);
                                                                                      return solution;
                                                                                  })
                                                       )
                            )
                        )
                            ? currentGame.Dices.Sum(d => d.Value)
                            : 0;
                        await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                            ContainsDiceNo(dices, 1),
                            ContainsDiceNo(dices, 2),
                            ContainsDiceNo(dices, 3),
                            ContainsDiceNo(dices, 4),
                            ContainsDiceNo(dices, 5));
                        break;
                    }
                case ScoreIndex.FullHouse:
                    {
                        (int diceA, int diceB, int diceC) dices = (0, 0, 0);
                        currentScore.FullHouse = currentGame.Dices.Any(d =>
                            currentGame.Dices.Any(e => d.Number != e.Number &&
                                                       currentGame.Dices.Any(f => d.Number != f.Number &&
                                                                                  currentGame.Dices.Any(g =>
                                                                                      d.Number != g.Number &&
                                                                                      currentGame.Dices.Any(h =>
                                                                                      {
                                                                                          var solution =
                                                                                              d.Number != h.Number &&
                                                                                              d.Value == e.Value &&
                                                                                              d.Value == f.Value &&
                                                                                              d.Value != g.Value &&
                                                                                              g.Value == h.Value;
                                                                                          if (solution)
                                                                                              dices = (d.Number, e.Number,
                                                                                                  f.Number);
                                                                                          return solution;
                                                                                      })
                                                                                  )
                                                       )
                            )
                        );
                        await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                            ContainsDiceNo(dices, 1),
                            ContainsDiceNo(dices, 2),
                            ContainsDiceNo(dices, 3),
                            ContainsDiceNo(dices, 4),
                            ContainsDiceNo(dices, 5));
                        break;
                    }
                case ScoreIndex.SmallStreet:
                    currentScore.SmallStreet = currentGame.Dices.Any(d =>
                        currentGame.Dices.Any(e => d.Number != e.Number &&
                            currentGame.Dices.Any(f => d.Number != f.Number &&
                                currentGame.Dices.Any(g => d.Number != g.Number &&
                                    d.Value == e.Value + 1 && d.Value == f.Value + 2 && d.Value == g.Value + 3))));
                    await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                        false,
                        false,
                        false,
                        false,
                        false);
                    break;
                case ScoreIndex.LargeStreet:
                    currentScore.LargeStreet = currentGame.Dices.Any(d =>
                        currentGame.Dices.Any(e => d.Number != e.Number &&
                            currentGame.Dices.Any(f => d.Number != f.Number &&
                                currentGame.Dices.Any(g => d.Number != g.Number &&
                                    currentGame.Dices.Any(h => d.Number != h.Number &&
                                        d.Value == e.Value + 1 && d.Value == f.Value + 2 && d.Value == g.Value + 3 && d.Value == h.Value + 4)))));
                    await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                        false,
                        false,
                        false,
                        false,
                        false);
                    break;
                case ScoreIndex.Yahtzee:
                    currentScore.Yahtzee = currentGame.Dices.Any(d =>
                        currentGame.Dices.Any(e => d.Number != e.Number &&
                            currentGame.Dices.Any(f => d.Number != f.Number &&
                                currentGame.Dices.Any(g => d.Number != g.Number &&
                                    currentGame.Dices.Any(h => d.Number != h.Number &&
                                        d.Value == e.Value && d.Value == f.Value && d.Value == g.Value && d.Value == h.Value)))));
                    await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                        false,
                        false,
                        false,
                        false,
                        false);
                    break;
                case ScoreIndex.Chance:
                    currentScore.Chance = currentGame.Dices.Sum(d => d.Value);
                    await _service.AssignResultRequestAndWaitForReceiptAsync(scoreAsIndex,
                        false,
                        false,
                        false,
                        false,
                        false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(scoreAs), scoreAs, null);
            }
        }

        private bool ContainsDiceNo((int diceA, int diceB, int diceC) dices, int targetNo)
        {
            return dices.diceA == targetNo || dices.diceB == targetNo || dices.diceC == targetNo;
        }

        private bool ContainsDiceNo((int diceA, int diceB, int diceC, int diceD) dices, int targetNo)
        {
            return dices.diceA == targetNo || dices.diceB == targetNo || dices.diceC == targetNo || dices.diceD == targetNo;
        }
        private bool ContainsDiceNo((int diceA, int diceB, int diceC, int diceD, int diceE) dices, int targetNo)
        {
            return dices.diceA == targetNo || dices.diceB == targetNo || dices.diceC == targetNo || dices.diceD == targetNo || dices.diceE == targetNo;
        }

        public async Task SendMessageAsync(string content)
        {
            await _service.SendMessageRequestAndWaitForReceiptAsync(System.Text.Encoding.UTF8.GetBytes(content));
        }
        //get last 16 messages from blockchain
        public async Task<string[]> ReceiveMessageAsync()
        {
            var receivedObject = await _service.ReceiveMessagesQueryAsync();
            var texts = receivedObject.ReturnValue1.Select(byteValue => System.Text.Encoding.UTF8.GetString(byteValue)).ToArray();
            return texts;
        }
    }
}
