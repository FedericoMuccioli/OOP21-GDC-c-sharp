using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OOPGDC
{
    /// <summary>
    /// Interface that models the methods for managing a single card.
    /// </summary>
    public interface Card
    {
        /// <summary>
        /// Enum with the 4 suits of the cards.
        /// </summary>
        enum Suits
        {
            CLUBS,
            DIAMONDS,
            HEARTS,
            SPADES
        }

        /// <summary>
        /// Rotate card changing the image.
        /// </summary>
        void TurnOver();

        /// <summary>
        /// Getter of the card.
        /// </summary>
        /// <returns> Card that is a pair of a suit and an int value </returns>
        Tuple<Suits, int> GetCard();

        /// <summary>
        /// Getter Suit.
        /// </summary>
        /// <returns> The suit of the card. </returns>
        Suits GetSuit();

        /// <summary>
        /// Getter Value.
        /// </summary>
        /// <returns> The points of the card.</returns>
        int GetValue();

        /// <summary>
        /// Getter Img.
        /// </summary>
        /// <returns> The image of the card.</returns>
        Image GetImg();

        /// <summary>
        /// Getter FaceDown.
        /// </summary>
        /// <returns> True if the card is facing down, false otherwise. </returns>
        Boolean IsFaceDown();

        /// <summary>
        /// Equals method.
        /// </summary>
        /// <param name="obj"> Object that will be compared.</param>
        /// <returns> True if the objects are the same.  </returns>
        Boolean Equals(Object obj);

        /// <summary>
        /// Generate hashcode.
        /// </summary>
        /// <returns> An int hashcode.</returns>
        int GetHashCode();



    }
}
