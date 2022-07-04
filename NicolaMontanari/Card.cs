using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OOPGDC
{
    public interface Card
    {
        enum Suits
        {
            CLUBS,
            DIAMONDS,
            HEARTS,
            SPADES
        }
        void TurnOver();

        Tuple<Suits, int> GetCard();

        Suits GetSuit();

        int GetValue();

        Image GetImg();

        Boolean IsFaceDown();


        Boolean Equals(Object obj);

        int GetHashCode();



    }
}
