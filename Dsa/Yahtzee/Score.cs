using System;
using System.Collections.Generic;
using System.Text;

namespace Yahtzee
{
    class Score
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

        public int FullHouse { get; set; }

        public int LowStraight { get; set; }

        public int HighStraight { get; set; }

        public bool Yahtzee { get; set; }

        public int Chance { get; set; }

        public bool Bonus { get; set; }
    }
}
