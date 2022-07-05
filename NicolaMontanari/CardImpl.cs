using System;
using System.Drawing;
using static OOPGDC.Card;

namespace OOPGDC
{
    /// <summary>
    /// Class that models the methods for handling a single card.
    /// </summary>
    public class CardImpl : Card
    {
        private readonly Tuple<Suits, int> card;
        private Boolean facedown;
        private Image img;

        /// <summary>
        ///  Generate a random card
        /// <!summary>
        public CardImpl() : this(GetRandomSuits(), GetRandomValue())
        {
            this.facedown = false;
        }

        /// <summary>
        ///  Generate a random card with precise suit
        /// <!summary>
        public CardImpl(Suits s) : this(s, GetRandomValue())
        {
        }

        /// <summary>
        ///  Generate a random card with precise value
        /// <!summary>
        public CardImpl(int value) : this(GetRandomSuits(), value)
        {
        }

        /// <summary>
        ///  Generate a random card face down
        /// <!summary>
        public CardImpl(Boolean isFacedown) : this(GetRandomSuits(), GetRandomValue())
        {
            this.facedown = isFacedown;
        }

        /// <summary>
        ///  Generate a precise card
        /// <!summary>
        public CardImpl(Suits s, int value) {
            this.card = new Tuple<Suits, int>(s, value);
            this.img = new Utilities().GetImage("img/cards/" + this.card.Item1 + "/" + this.card.Item2 + ".png");
            this.facedown = false;
        }

        public Suits GetSuit()
        {
            return this.card.Item1;
        }

        public int GetValue()
        {
            return (this.card.Item2 >= 10) ? 10 : this.card.Item2;
        }

        public Image GetImg()
        {
            return this.img;
        }

        public Tuple<Suits, int> GetCard()
        {
            return this.card;
        }

        public Boolean IsFaceDown()
        {
            return this.facedown;
        }

        private Boolean IsRedColored()
        {
            return (this.card.Item1 == Suits.DIAMONDS || this.card.Item1 == Suits.HEARTS);
        }

        public void TurnOver()
        {
            if (this.facedown)
            {
                this.img = new Utilities().GetImage("img/cards/" + this.card.Item1 + "/" + this.card.Item2 + ".png");
                this.facedown = false;
            }
            else
            {
                if (IsRedColored())
                {
                    this.img = new Utilities().GetImage("img/cards/back/red.png");
                }
                else
                {
                    this.img = new Utilities().GetImage("img/cards/back/black.png");
                }
                this.facedown = true;
            }
        }

        private static Suits GetRandomSuits()
        {
            return (Suits) Enum.GetValues(typeof(Suits)).GetValue(new Random().Next(0,4));
        }

        private static int GetRandomValue()
        {
            return new Random().Next(1, 14);
        }

        override
        public int GetHashCode()
        {
            return this.GetHashCode();
        }

        override
        public Boolean Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            Card other = (Card)obj;
            return Object.Equals(this.card.Item1, other.GetSuit()) && Object.Equals(this.card.Item2, other.GetValue());
        }
    }
}
