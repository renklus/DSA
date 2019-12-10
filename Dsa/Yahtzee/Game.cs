using System;
using System.Collections.Generic;
using System.Text;
using Yahtzee;

namespace Yahtzee
{
    public class Game
    {
        public Game()
        {
            for (int i = 0; i < 5; i++)
            {
                Dices[i] = new Dice(){Number=i+1};
            }
        }

        public Dice[] Dices = new Dice[4];
        public int Round { get; set; }

    }
}
