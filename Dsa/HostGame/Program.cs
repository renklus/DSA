using System;
using System.Security;
using System.Threading.Tasks;
using Yahtzee;

namespace HostGame
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var manager = new YahtzeeManager(Settings.Settings.PrivateKey);
            var gameId = await manager.StartGameAsync(Settings.Settings.PrivateAddress);

            Console.Out.WriteLine(gameId);

            var gameState = await manager.ThrowDiceAndGetGameAsync(true, true, true, true, true);

            for (int i = 0; i < 5; i++)
            {
                Console.Out.WriteLine($"Dice {gameState.Dices[i].Number}: {gameState.Dices[i].Value}");
            }

            User user = new User()
            { Name = "-", PrivateKey = Settings.Settings.PrivateKey, Wallet = Settings.Settings.PrivateAddress };
            Score score = new Score() { Owner = user };

            await manager.ScoreAsync(score, gameState, ScoreIndex.Ones);
            //await manager.ScoreAsync(score, gameState, ScoreIndex.Twos);

            await manager.ThrowDiceAndUpdateGameAsync(gameState, true, true, true, true, true);
            await manager.ThrowDiceAndUpdateGameAsync(gameState, true, true, true, false, false);
            await manager.ThrowDiceAndUpdateGameAsync(gameState, true, true, true, false, false);

            await manager.ScoreAsync(score, gameState, ScoreIndex.Twos);
            
            await manager.ThrowDiceAndUpdateGameAsync(gameState, true, true, true, true, true);
            await manager.ThrowDiceAndUpdateGameAsync(gameState, true, true, true, false, false);
            await manager.ThrowDiceAndUpdateGameAsync(gameState, true, true, true, false, false);
            await manager.ThrowDiceAndUpdateGameAsync(gameState, true, true, true, false, false);

        }
    }
}
