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

            Console.Out.WriteLine($"Dice 1: {gameState.Dices[0]}");
            Console.Out.WriteLine($"Dice 2: {gameState.Dices[1]}");
            Console.Out.WriteLine($"Dice 3: {gameState.Dices[2]}");
            Console.Out.WriteLine($"Dice 4: {gameState.Dices[3]}");
            Console.Out.WriteLine($"Dice 5: {gameState.Dices[4]}");

            User user = new User()
            { Name = "-", PrivateKey = Settings.Settings.PrivateKey, Wallet = Settings.Settings.PrivateAddress };
            Score score = new Score() { Owner = user };

            await manager.ScoreAsync(score, gameState, ScoreIndex.Ones);
            await manager.ScoreAsync(score, gameState, ScoreIndex.Twos);

            //var gameState = await manager.ThrowDiceAndGetGameAsync(true, true, true, true, true);

        }
    }
}
