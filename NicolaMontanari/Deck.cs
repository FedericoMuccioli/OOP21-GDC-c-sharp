using System;
using System.Collections.Generic;
using System.Text;

namespace OOPGDC
{
    interface Deck
    {
        /**
         * Fill the deck with cards.
         */
        void GenerateDeck();

        /**
         * Remove a card from a deck.
         * 
         * @param card Card to be removed.
         * @return true if the card has been successfully removed.
         */
        Boolean RemovePreciseCard(Card card);

        /**
         * Remove a random card from the deck.
         * 
         * @return true if the card has been successfully removed.
         */
        Boolean RemoveRandomCard();

        /**
         * Remove and return a card from the deck.
         * 
         * @param card the card that needs to be removed.
         * @return the card removed.
         */
        Card DrawPreciseCard(Card card);

        /**
         * Remove and return a random card from the deck.
         * 
         * @return the card removed.
         */
        Card DrawRandomCard();

        /**
         * Reinitialize the deck with new cards.
         */
        void Shuffle();

        /**
         * Getter nDecks.
         * @return the numbers of decks.
         */
        int GetnDecks();

        /**
         * getter size. 
         * @return the size of the deck.
         */
        int Size();


    }
}
