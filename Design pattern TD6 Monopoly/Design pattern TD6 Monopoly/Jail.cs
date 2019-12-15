using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_TD6_Monopoly
{
    class Jail:Position
    {
        public List<Player> prisoners;
        private static Jail jail = null;
        private static readonly object padlock = new object();
        Jail() : base(10)
        {
            prisoners = new List<Player>();
        }
        public bool isPrisonner(Player p)
        {
            if (prisoners.Contains(p)) { return true; }
            return false;
        }
        public static Jail myJail
        {
            get
            {
                lock (padlock)
                {
                    if (jail == null)
                    {
                        jail = new Jail();
                    }
                    return jail;
                }
            }
        }
    }
}
