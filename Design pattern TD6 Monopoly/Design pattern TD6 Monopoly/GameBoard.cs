using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_TD6_Monopoly
{
    class GameBoard
    {
        public Position[] position = new Position[40];
        private static readonly object padlock = new object();
        static GameBoard myGameboard= null;
        GameBoard()
        {
                for (int i = 0; i < 40; i++)
                {
                    if (i != 10)
                    {
                        position[i] = new Position(i);
                    }
                    else
                    {
                        position[i] = Jail.myJail;
                    }
                }
                for (int i = 1; i < 39; i++)
                {
                    position[i].prev = position[i - 1];
                    position[i].next = position[i + 1];
                }
                position[0].prev = position[39];
                position[0].next = position[1];
                position[39].prev = position[38];
                position[39].next = position[0];
            
        }

        public static GameBoard MyGameBoard
        {
            get
            {
                lock (padlock)
                {
                    if (myGameboard == null)
                    {
                        myGameboard = new GameBoard();
                    }
                    return myGameboard;
                }
            }
        }
    }
}
