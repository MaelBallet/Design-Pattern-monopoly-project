using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_TD6_Monopoly
{
    class View
    {
        private char[][] board = new char[45][];
        private int[] posI = { 41, 41, 41, 41, 41, 41, 41, 41, 41, 41, 41, 37, 33, 29, 25, 21, 17, 13, 9, 5, 1, 1, 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 5 , 9 , 13, 17, 21, 25, 29, 33, 37 };
        private int[] posJ = { 81, 73, 65, 57, 49, 41, 33, 25, 17, 9 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1 , 1, 1, 1, 9, 17, 25, 33, 41, 49, 57, 65, 73, 81, 81, 81, 81, 81, 81, 81, 81, 81, 81 };
        private int[] insideI = { 1, 1, 1, 0, 2, 0, 0, 2, 2 };
        private int[] insideJ = { 3, 1, 5, 3, 3, 1, 5, 1, 5 };

        public View()
        {
            string fullLimLine = " --------------------------------------------------------------------------------------- ";
            string fullnormalLine = "|       |       |       |       |       |       |       |       |       |       |       |";
            string LimLine = " -------                                                                         ------- ";
            string normalLine = "|       |                                                                       |       |";
            for (int i = 0; i < 45; i++)
            {
                board[i] = new char[89];
                for (int j = 0; j < 89; j++)
                {
                    if (i == 0 || i == 4 || i == 40 || i == 44)
                    {
                        board[i][j] = fullLimLine[j];
                    }
                    else if (i == 1 || i == 2 || i == 3 || i == 41 || i == 42 || i == 43)
                    {
                        board[i][j] = fullnormalLine[j];
                    }
                    else if (i % 4 == 0)
                    {
                        board[i][j] = LimLine[j];
                    }
                    else
                    {
                        board[i][j] = normalLine[j];
                    }
                }
            }
            string gameName = "MONOPOLY";
            for (int i = 0; i < 8; i++)
            {
                board[i + 18][2 * i + 36] = gameName[i];
            }
            string author = "YANN ABOU JAOUDE ESILV A4 IBO 01              10/11/2019";
            for (int i = 0; i < author.Length; i++)
            {
                board[10][i + 16] = author[i];
            }
            author = "MAEL BALLET      ESILV A4 IBO 01              10/11/2019";
            for (int i = 0; i < author.Length; i++)
            {
                board[11][i + 16] = author[i];
            }
        }
        public void showBoard()
        {
            Console.Clear();
            for (int i = 0; i < 45; i++)
            {
                Console.WriteLine(board[i]);
            }
        }
        public void updatePosition(Position position)
        {
            //clean the position
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    board[posI[position.number] + i][posJ[position.number] + j] = ' ';
                }
            }
            //put all player and organise them in the position
            for (int i = 0; i < position.players.Count; i++)
            {
                board[posI[position.number] + insideI[i]][posJ[position.number] + insideJ[i]] = position.players[i].sign;
            }
        }
        public void updateMessage(string message)
        {
            for (int i = 0; i < 64; i++)
            {
                board[30][i + 16] = ' ';
            }
            for (int i = 0; i < message.Length; i++)
            {
                board[30][i + 16] = message[i];
            }
        }
        public void updateDices(Dice dice1, Dice dice2)
        {
            board[35][60] = (char)(dice1.number+48);
            board[36][60] = (char)(dice2.number+48);
        }
    }
}
