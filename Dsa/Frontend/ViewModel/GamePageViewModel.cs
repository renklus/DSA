using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Frontend.Views;
using Yahtzee;

namespace Frontend.ViewModel
{
    public class GamePageViewModel : BindableBase
    {
        private string _gameid;

        public string GameId
        {
            get { return _gameid; }
            set { SetProperty(ref _gameid, value); }
        }

        public Game CurrentGame { get; set; }

        public GamePageViewModel(Game currentgame)
        {
            this.CurrentGame = currentgame;
            this.GameId = SettingsStore.GameId;
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

        private bool _changeDiceOne = true;
        public bool ChangeDiceOne
        {
            get { return _changeDiceOne; }
            set { SetProperty(ref _changeDiceOne, value); }
        }


        private bool _changeDiceTwo = true;
        public bool ChangeDiceTwo
        {
            get { return _changeDiceTwo; }
            set { SetProperty(ref _changeDiceTwo, value); }
        }

        private bool _changeDiceThree = true;
        public bool ChangeDiceThree
        {
            get { return _changeDiceThree; }
            set { SetProperty(ref _changeDiceThree, value); }
        }

        private bool _changeDiceFour = true;
        public bool ChangeDiceFour
        {
            get { return _changeDiceFour; }
            set { SetProperty(ref _changeDiceFour, value); }
        }

        private bool _changeDiceFive = true;
        public bool ChangeDiceFive
        {
            get { return _changeDiceFive; }
            set { SetProperty(ref _changeDiceFive, value); }
        }

        private bool _buttonEnabled = true;
        public bool ButtonEnabled
        {
            get { return _buttonEnabled; }
            set { SetProperty(ref _buttonEnabled, value); }
        }

        public async Task Reroll()
        {
            ButtonEnabled = false;

            var result = await SettingsStore.YahtzeeManager.ThrowDiceAsync(ChangeDiceOne, ChangeDiceTwo, ChangeDiceThree,
                   ChangeDiceFour, ChangeDiceFive);

            DiceOne = result[0];
            DiceTwo = result[1];
            DiceThree = result[2];
            DiceFour = result[3];
            DiceFive = result[4];

            ButtonEnabled = true;
        }
    }
}
