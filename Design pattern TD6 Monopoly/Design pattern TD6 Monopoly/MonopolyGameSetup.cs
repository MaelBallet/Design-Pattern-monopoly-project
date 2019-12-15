using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_TD6_Monopoly
{
    class MonopolyGameSetup
    {
        static int numberOfTurn = 25;
        public List<Player> players;
        Dice[] dices;
        GameBoard board;
        View view;
        PositionController positionController;
        PlayerController playerControler;
        private static MonopolyGameSetup myMonopoly = null;
        private static readonly object padlock = new object();
        MonopolyGameSetup()
        {
            view = new View();
            dices = new Dice[2];
            positionController = new PositionController();
            playerControler = new PlayerController(positionController,view);
            dices[0] = new Dice(new Random(12));
            dices[1] = new Dice(new Random(40));
            view.updateMessage("How many players?");
            view.showBoard();
            int numberOfPlayer = askNumberOfPlayer();
            players = new List<Player>();
            for (int i = 0; i < numberOfPlayer; i++)
            {
                view.updateMessage("Please enter player "+ (i+1)+" name");
                view.showBoard();
                string name = askName();
                view.updateMessage("Please enter player " + (i + 1) + " sign");
                view.showBoard();
                players.Add(new Player(name, askSign()));
            }
            for (int i = 0; i < numberOfPlayer-1; i++)
            {
                players[i].next= players[i+1];
            }
            players[numberOfPlayer - 1].next = players[0];
            board = GameBoard.MyGameBoard;
            positionController.initialize(players,board);
            view.updatePosition(board.position[0]);
            view.showBoard();
            

        }
        public static void MonopolyParty()
        {
            
            for (int i = 0; i < numberOfTurn; i++)
            {
                for (int j = 0; j < MyMonopoly.players.Count; j++)
                {
                    MyMonopoly.playerControler.playATurn(MyMonopoly.players[j], MyMonopoly.dices);
                }
            }
        }
        static MonopolyGameSetup MyMonopoly
        {
            get
            {
                lock (padlock)
                {
                    if (myMonopoly == null)
                    {
                        myMonopoly = new MonopolyGameSetup();
                    }
                    return myMonopoly;
                }
            }
        }
        public static int askNumberOfPlayer()
        {
            return int.Parse(Console.ReadLine());
        }
        public static char askSign()
        {
            return Console.ReadLine()[0];
        }
        public static string askName()
        {
            return Console.ReadLine();
        }
    }
}
