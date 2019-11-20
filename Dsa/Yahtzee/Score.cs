using System;
using System.Collections.Generic;
using System.Text;

namespace Yahtzee
{
    public class Score
    {
        public User Owner { get; set; }

        public int Ones { get; set; }

        public int Twos { get; set; }

        public int Threes { get; set; }

        public int Fours { get; set; }

        public int Fives { get; set; }

        public int Sixes { get; set; }

        public int ThreeOfAKind { get; set; }

        public int FourOfAKind { get; set; }

        public bool FullHouse { get; set; }

        public bool LowStraight { get; set; }

        public bool HighStraight { get; set; }

        public bool Yahtzee { get; set; }

        public int Chance { get; set; }
    }
}
