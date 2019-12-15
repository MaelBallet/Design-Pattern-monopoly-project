using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_TD6_Monopoly
{
    class Dice
    {
        public int number;
        private Random rand;
        public Dice(Random rand)
        {
            this.rand = rand;
        }

        public void shuffle()
        {
            number = rand.Next(6) + 1;
        }
    }
}
