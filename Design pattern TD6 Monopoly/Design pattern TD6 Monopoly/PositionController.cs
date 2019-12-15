using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_TD6_Monopoly
{
    class PositionController
    {
        public PositionController()
        {
        }
        public void initialize(List<Player> players, GameBoard Board)
        {
            foreach(Player p in players)
            {
                p.position = Board.position[0];
                Board.position[0].players.Add(p);               
            }
        }
        public void moveForward(int range, Player currentPlayer)
        {
            for (int i = 0; i < range; i++)
            {
                currentPlayer.position.players.Remove(currentPlayer);
                currentPlayer.position = currentPlayer.position.next;
                currentPlayer.position.players.Add(currentPlayer);
                
            }
            
            //visit jail?
        }
        
    }
}
