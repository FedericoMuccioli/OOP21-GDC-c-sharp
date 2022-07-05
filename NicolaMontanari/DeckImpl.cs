using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static OOPGDC.Card;

namespace OOPGDC
{
    /// <summary>
    /// Class that implements card deck management methods.
    /// </summary>
    class DeckImpl : ArrayList, Deck
    {
        private readonly int ndeck;

        public DeckImpl(int ndeck)
        {
            this.ndeck = ndeck;
        }

        public void GenerateDeck()
        {
            for (int counter = 1; counter <= this.ndeck; counter++)
            {
                foreach (Suits s in Enum.GetValues(typeof(Suits)))
                {
                    for (int i = 1; i <= 13; i++)
                    {
                        this.Add(new CardImpl(s, i));
                    }
                }
            }
        }

        public void Shuffle()
        {
            this.RemoveRange(0, this.Size());
            GenerateDeck();
        }
        
        public Boolean RemovePreciseCard(Card card)
        {
            int i = 0;
            foreach (Card c in this)
            {
                if (c.GetSuit() == card.GetSuit() && c.GetCard().Item2 == card.GetCard().Item2)
                {
                    this.RemoveAt(i);
                    return true;
                }
                i++;
            }
            return false;
        }

        public Boolean RemoveRandomCard()
        {
            if (this.Size() != 0)
            {
                this.Remove(this[new Random().Next(0,this.Size())]);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Card DrawPreciseCard(Card card)
        {
            if (this.Size() != 0)
            {
                int i = 0;
                foreach (Card c in this)
                {
                    if (c.GetSuit() == card.GetSuit() && c.GetCard().Item2 == card.GetCard().Item2)
                    {
                        this.RemoveAt(i);
                        return card;
                    }
                    i++;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public Card DrawRandomCard()
        {
            if (this.Size() != 0)
            {
                Card c = (Card) this[new Random().Next(0, this.Size())];
                this.Remove(c);
                return c;
            }
            else
            {
                return null;
            }
        }

        public int GetnDecks()
        {
            return this.ndeck;
        }

        public int Size()
        {
            int counter = 0;
            foreach (Card c in this)
            {
                counter++;
            }
            return counter;
        }
    }
}
