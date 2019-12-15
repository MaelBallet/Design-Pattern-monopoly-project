using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_TD6_Monopoly
{
    class Player
    {
        public string name;
        public char sign;
        public Position position;
        public Player next;
        public int doubleInARow;
        public int turnInJail;
        public Player(string name,char sign)
        {
            this.name = name;
            this.sign = sign;
        }
        public override string ToString()
        {
            return name + " " + sign;
        }
    }
}
