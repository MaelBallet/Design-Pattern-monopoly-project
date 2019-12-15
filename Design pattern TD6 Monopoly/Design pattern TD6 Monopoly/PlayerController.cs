using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_pattern_TD6_Monopoly
{
    class PlayerController
    {       
        public PositionController positionController;
        public View view;
        public PlayerController(PositionController positionController,View view)
        {
            this.positionController = positionController;
            this.view = view;
        }
        public void playATurn(Player currentPlayer, Dice[]dices)
        {
            view.updateMessage(currentPlayer.ToString() + " is taking his turn");
            if (Jail.myJail.isPrisonner(currentPlayer))
            {
                aTurnInJail(currentPlayer, dices);
            }
            else
            {
                currentPlayer.doubleInARow = 0;
                Position old;
                dices[0].shuffle();
                dices[1].shuffle();
                view.updateDices(dices[0], dices[1]);
                old = currentPlayer.position;
                positionController.moveForward(dices[0].number + dices[1].number, currentPlayer);
                view.updatePosition(currentPlayer.position);
                view.updatePosition(old);
                view.showBoard();
                System.Threading.Thread.Sleep(500);
                while (dices[0].number == dices[1].number && currentPlayer.doubleInARow != 2)
                {
                    currentPlayer.doubleInARow++;
                    dices[0].shuffle();
                    dices[1].shuffle();
                    view.updateDices(dices[0], dices[1]);
                    old = currentPlayer.position;
                    positionController.moveForward(dices[0].number + dices[1].number, currentPlayer);
                    view.updatePosition(currentPlayer.position);
                    view.updatePosition(old);
                    view.showBoard();
                    System.Threading.Thread.Sleep(500);
                }
                if (dices[0].number == dices[1].number)
                {
                    goToJail(currentPlayer);
                }
                else if (currentPlayer.position.number==30)
                {
                    goToJail(currentPlayer);
                }
            }
            
        }
        public void goToJail(Player currentPlayer)
        {
            view.updateMessage("Player " + currentPlayer + " have been a bad boy and is going to jail");
            System.Threading.Thread.Sleep(500);
            Position old;
            old = currentPlayer.position;
            while (!(currentPlayer.position.number==10))
            {
                positionController.moveForward(1, currentPlayer);
            }
            view.updatePosition(currentPlayer.position);
            view.updatePosition(old);
            Jail.myJail.prisoners.Add(currentPlayer);
            currentPlayer.turnInJail = 0;
        }
        public void aTurnInJail(Player currentPlayer, Dice[] dices)
        {
            currentPlayer.turnInJail++;
            if (currentPlayer.turnInJail > 3)
            {
                view.updateMessage(currentPlayer.ToString() + " is in jail since 3 turns and can now get out");
                Jail.myJail.prisoners.Remove(currentPlayer);
                currentPlayer.turnInJail = 0;
                System.Threading.Thread.Sleep(500);
                playATurn(currentPlayer, dices);
            }
            else
            {
                view.updateMessage(currentPlayer.ToString() + " is taking his turn in Jail");
                Position old;
                dices[0].shuffle();
                dices[1].shuffle();
                view.updateDices(dices[0], dices[1]);
                old = currentPlayer.position;
                System.Threading.Thread.Sleep(500);
                if (dices[0].number == dices[1].number)
                {
                    view.updateMessage(currentPlayer.ToString() + " have done a double so he can get out of Jail and play his turn");
                    positionController.moveForward(dices[0].number + dices[1].number, currentPlayer);
                    Jail.myJail.prisoners.Remove(currentPlayer);
                    currentPlayer.turnInJail = 0;
                }
                view.updatePosition(currentPlayer.position);
                view.updatePosition(old);
                view.showBoard();
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
