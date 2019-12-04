﻿using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Views;

namespace Frontend.ViewModel
{
    class GameViewModel : BindableBase
    {


        public Game Game { get; set; }

        public GameViewModel(Game game)
        {
            this.Game = game;
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
    }
}
