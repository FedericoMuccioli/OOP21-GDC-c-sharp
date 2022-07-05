using System;
using System.Collections.Generic;
using System.Text;

namespace OOPGDC
{
    /// <summary>
    /// Interface for managing decks of cards.
    /// </summary>
    interface Deck
    {
        /// <summary>
        /// Fill the deck with cards.
        /// </summary>
        void GenerateDeck();

        /// <summary>
        /// Remove a card from a deck.
        /// </summary>
        /// <param name="card"> Card to be removed. </param>
        /// <returns> True if the card has been successfully removed. </returns>
        Boolean RemovePreciseCard(Card card);

        /// <summary>
        /// Remove a random card from the deck.
        /// </summary>
        /// <returns> True if the card has been successfully removed. </returns>
        Boolean RemoveRandomCard();

        /// <summary>
        /// Remove and return a card from the deck.
        /// </summary>
        /// <param name="card"> The card that needs to be removed.</param>
        /// <returns> The card removed.</returns>
        Card DrawPreciseCard(Card card);

        /// <summary>
        /// Remove and return a random card from the deck.
        /// </summary>
        /// <returns> The card removed. </returns>
        Card DrawRandomCard();

        /// <summary>
        /// Reinitialize the deck with new cards.
        /// </summary>
        void Shuffle();

        /// <summary>
        /// Getter nDecks.
        /// </summary>
        /// <returns> The numbers of decks. </returns>
        int GetnDecks();

        /// <summary>
        /// Getter size.
        /// </summary>
        /// <returns> The size of the deck.</returns>
        int Size();
    }
}
