using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_TD6_Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
           /*  View myview = new View();
             myview.showBoard();
            Console.ReadKey();
            myview.updateMessage("HEY c'est trop cool");
            myview.showBoard();
            Console.ReadKey();
            myview.updateMessage("Viens on fait la fete");
            myview.showBoard();*/
            /*Player yann = new Player("Yann", 'Y');
            Player Mael = new Player("Yann", 'Y');*/
            MonopolyGameSetup.MonopolyParty();


            Console.ReadKey();
        }
    }
}
