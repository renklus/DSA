using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frontend.Views;
using Yahtzee;

namespace Frontend.ViewModel
{
    public class GameViewPageModel : BindableBase
    {

        public int[] Dices = new int[5];

        private string _gameid;

        public string GameId
        {
            get { return _gameid; }
            set { SetProperty(ref _gameid, value); }
        }

        public Game CurrentGame { get; set; }

        public GameViewPageModel(Game currentgame)
        {
            this.CurrentGame = currentgame;
            this.GameId = SettingsStore.GameId;
            Roll();
        }

        private int _diceone;
        public int DiceOne
        {
            get { return _diceone; }
            set { SetProperty(ref _diceone, value); }
        }

        private int _dicetwo;
        public int DiceTwo
        {
            get { return _dicetwo; }
            set { SetProperty(ref _dicetwo, value); }
        }

        private int _dicethree;
        public int DiceThree
        {
            get { return _dicethree; }
            set { SetProperty(ref _dicethree, value); }
        }

        private int _dicefour;
        public int DiceFour
        {
            get { return _dicefour; }
            set { SetProperty(ref _dicefour, value); }
        }

        private int _dicefive;
        public int DiceFive
        {
            get { return _dicefive; }
            set { SetProperty(ref _dicefive, value); }
        }

        public async Task Roll()
        {
            Dices = await SettingsStore.YahtzeeManager.GetDiceAsync();
            DiceOne = Dices[0];
            DiceTwo = Dices[1];
            DiceThree = Dices[2];
            DiceFour = Dices[3];
            DiceFive = Dices[4];

        }
    }
}
