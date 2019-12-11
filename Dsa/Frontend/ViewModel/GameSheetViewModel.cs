using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks.Sources;
using Yahtzee;
using Frontend.Commands;

namespace Frontend.ViewModel
{
    public class GameSheetViewModel : BindableBase
    {
        public RelayCommand SaveCommand { get; set; }

        public Score Score { get; set; }

        public GameSheetViewModel(Score score)
        {
            Load(score);
            SaveCommand = new RelayCommand(Save);
        }

        private int _ones;
        public int Ones
        {
            get { return _ones; }
            set { SetProperty(ref _ones, value);  }
        }

        private int _twos;
        public int Twos
        {
            get { return _twos; }
            set { SetProperty(ref _twos, value); }
        }

        private int _threes;
        public int Threes
        {
            get { return _threes; }
            set { SetProperty(ref _threes, value); }
        }

        private int _fours;
        public int Fours
        {
            get { return _fours; }
            set { SetProperty(ref _fours, value); }
        }

        private int _fives;
        public int Fives
        {
            get { return _fives; }
            set { SetProperty(ref _fives, value); }
        }

        private int _sixes;
        public int Sixes
        {
            get { return _sixes; }
            set { SetProperty(ref _sixes, value); }
        }

        private int _threeofakind;
        public int ThreeOfAKind
        {
            get { return _threeofakind; }
            set { SetProperty(ref _threeofakind, value);  }
        }

        private int _fourofakind;
        public int FourOfAKind
        {
            get { return _fourofakind; }
            set { SetProperty(ref _fourofakind, value); }
        }

        private bool _fullhouse;
        public bool FullHouse
        {
            get { return _fullhouse; }
            set { SetProperty(ref _fullhouse, value); }
        }

        private bool _lowstraight;
        public bool LowStraight
        {
            get { return _lowstraight; }
            set { SetProperty(ref _lowstraight, value); }
        }

        private bool _highstraight;
        public bool HighStraight
        {
            get { return _highstraight; }
            set { SetProperty(ref _highstraight, value); }
        }

        private bool _yahtzee;
        public bool Yahtzee
        {
            get { return _yahtzee; }
            set { SetProperty(ref _yahtzee, value); }
        }

        private int _chance;
        public int Chance
        {
            get { return _chance; }
            set { SetProperty(ref _chance, value); }
        }

        public Action<Score> OnSave { get; set; }


        public void Load(Score score)
        {
            Ones = score.Ones;
            Twos = score.Twos;
            Threes = score.Threes;
            Fours = score.Fours;
            Fives = score.Fives;
            Sixes = score.Sixes;
            ThreeOfAKind = score.ThreeOfAKind;
            FourOfAKind = score.FourOfAKind;
            FullHouse = score.FullHouse;
            LowStraight = score.SmallStreet;
            HighStraight = score.LargeStreet;
            Yahtzee = score.Yahtzee;
            Chance = score.Chance;
        }

        public void Save()
        {
            Score.Ones = Ones;
            Score.Twos = Twos;
            Score.Threes = Threes;
            Score.Fours = Fours;
            Score.Fives = Fives;
            Score.Sixes = Sixes;
            Score.ThreeOfAKind = ThreeOfAKind;
            Score.FourOfAKind = FourOfAKind;
            Score.FullHouse = FullHouse;
            Score.SmallStreet = LowStraight;
            Score.LargeStreet = HighStraight;
            Score.Yahtzee = Yahtzee;
            Score.Chance = Chance;

            OnSave?.Invoke(Score);
        }
    }
}
