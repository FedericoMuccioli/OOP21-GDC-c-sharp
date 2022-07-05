using System;
using System.Collections.Generic;
using System.Text;

namespace OOPGDC
{
    /// <summary>
    /// Interface that manages the methods of managing the hands of the players and the dealer.
    /// </summary>
    interface Hand
    {

        /// <summary>
        /// Add a card to the hand. 
        /// </summary>
        /// <param name="c"> Card that will be added. </param>
        /// <returns> True if the card has been added, false otherwise. </returns>
        Boolean AddCard(Card c);

        /// <summary>
        /// Remove a card to the hand.
        /// </summary>
        /// <param name="c"> Card that will be removed. </param>
        /// <returns> True if the card has been removed, false otherwise. </returns>
        Boolean RemoveCard(Card c);

        /// <summary>
        /// Calculate the points of the hand.
        /// </summary>
        void CalculatePoints();

        /// <summary>
        /// Getter card.
        /// </summary>
        /// <param name="index"> Index of the card in the hand. </param>
        /// <returns> The card requested. </returns>
        Card GetCard(int index);

        /// <summary>
        /// Getter the last card of the hand.
        /// </summary>
        /// <returns> The card requested. </returns>
        Card GetLastCard();

        /// <summary>
        /// Getter of the hand. 
        /// </summary>
        /// <returns> The whole hand. </returns>
        Hand GetHand();

        /// <summary>
        /// Getter of points for Baccarat Game. 
        /// </summary>
        /// <returns> An int with baccarat points. </returns>
        int GetBaccaratPoints();

        /// <summary>
        /// Getter of points for Blackjack Game. 
        /// </summary>
        /// <returns> An int with Blackjack points. </returns>
        int GetBlackJackPoints();

        /// <summary>
        /// Getter size of the hand.
        /// </summary>
        /// <returns> Amount of elements in the hand. </returns>
        int Size();
    }
}
