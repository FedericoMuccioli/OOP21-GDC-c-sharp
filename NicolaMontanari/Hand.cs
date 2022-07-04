using System;
using System.Collections.Generic;
using System.Text;

namespace OOPGDC
{
    interface Hand
    {

        /**
         * Add a card to the hand. 
         * 
         * @param c card that will be added.
         * @return true if the card has been added, false otherwise.
         */
        Boolean AddCard(Card c);

        /**
         * Remove a card to the hand.
         * 
         * @param c card that will be removed.
         * @return true if the card has been removed, false otherwise. 
         */
        Boolean RemoveCard(Card c);


        /**
         * Calculate the points of the hand.
         */
        void CalculatePoints();

        /**
         * Getter card.
         * 
         * @param index index of the card in the hand.
         * @return the card requested.
         */
        Card GetCard(int index);

        /**
         * Getter the last card of the hand.
         * 
         * @return the card requested.
         */
        Card GetLastCard();

        /**
         * Getter of the hand. 
         * 
         * @return the whole hand. 
         */
        Hand GetHand();

        /**
         * Getter of points for Baccarat Game. 
         * 
         * @return an int with baccarat points.
         */
        int GetBaccaratPoints();

        /**
         * Getter of points for Blackjack Game. 
         * 
         * @return an int with Blackjack points.
         */
        int GetBlackJackPoints();

        /**
         * Getter size of the hand.
         * 
         * @return amount of elements in the hand. 
         */
        int Size();
    }
}
