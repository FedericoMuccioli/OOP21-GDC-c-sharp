using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OOPGDC
{
    /// <summary>
    /// Interface that models the baccart logic game.
    /// </summary>
    public interface BaccaratLogic
    {
        

        /// <summary>
        /// Inizialize game from selected bet
        /// </summary>
        void startGame(final double bet);

        /// <summary>
        /// Define next move of the game, calling nextDealerMove and nextPlayerMove
        /// </summary>
        void nextMove();

        /// <summary>
        ///check who win
        /// </summary>
        /// <returns> 1 for player wins, -1 for dealer wins and 0 for tie </returns>
	int checkWin();

	
	/// <summary>
        /// Define the next move of the player, he can draw or do nothing
        /// </summary>
        void nextPlayerMove();      


        /// <summary>
        /// Define the next move of the dealer, he can draw or do nothing
        /// </summary>
        void nextDealerMove();


	/// <summary>
        /// Dealer draw a card
        /// </summary>
        void DealerDraw();


	/// <summary>
        /// Player draw a card
        /// </summary>
        void playerDraw();


        /// <summary>
        /// Equals method.
        /// </summary>
        /// <param name="h"> hand of the dealer/player </param>
        /// <returns>  true if the hand in input have baccarat, false otherwise  </returns>
        boolean checkBaccarat(Hand h);


        /// <summary>
        /// end of the game
        /// </summary>
        void endGame();


        /// <summary>
        /// get the player hand
        /// </summary>
	/// <returns>  Player hand  </returns>
	Hand getPlayerHand();


        /// <summary>
        /// get the dealer hand
        /// </summary>
	/// <returns>  Dealer hand  </returns>
	Hand getDealerHand();


        /// <summary>
        /// get the dealer points
        /// </summary>
	/// <returns>  Dealer total points </returns>
	int getDealerPoints();


        /// <summary>
        /// get the player points
        /// </summary>
	/// <returns>  Player total points </returns>
	int getPlayerPoints();


        /// <summary>
        /// get the player bet
        /// </summary>
        /// <returns> the bet set by the player </returns>
        double getBet();



    }
}