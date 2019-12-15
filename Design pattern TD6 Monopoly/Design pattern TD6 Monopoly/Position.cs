using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_TD6_Monopoly
{
    class Position
    {
        public int number;
        public Position prev;
        public Position next;
        public List<Player> players;
        public Position(int number)
        {
            this.number = number;
            players = new List<Player>();        
        }
    }
}
