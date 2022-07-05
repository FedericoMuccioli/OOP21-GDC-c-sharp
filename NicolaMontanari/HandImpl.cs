using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPGDC
{
    /// <summary>
    /// Class that implements the methods of handling the hands of the players and the dealer.
    /// </summary>
    class HandImpl : LinkedList<Card>, Hand
    {
        private int points;

        public HandImpl()
        {
            this.points = 0;
        }

        public Boolean AddCard(Card c)
        {
            this.AddLast(c);
            return true;
        }

        public Boolean RemoveCard(Card c)
        {
            return this.Remove(c);
        }

        public void CalculatePoints()
        {
            this.points = 0;
            Boolean ace = false;
            Boolean converted = false;
            foreach (Card c in this)
            {
                if (c.GetValue() == 1 && !ace)
                {
                    this.points += (c.GetValue() + 10);
                    ace = true;
                }
                else
                {
                    this.points += c.GetValue();
                }
                if (this.points > 21 && ace && !converted)
                {
                    this.points -= 10;
                    converted = true;
                }
            }
        }

        public Card GetCard(int index)
        {
            return this.ElementAt(index);
        }

        public Hand GetHand()
        {
            return this;
        }

        public int GetBlackJackPoints()
        {
            return this.points;
        }

        public int GetBaccaratPoints()
        {
            return this.points % 10;
        }

        public int Size()
        {
            int i = 0;
            foreach (Card c in this)
            {
                i++;
            }
            return i;
        }

        public Card GetLastCard()
        {
            return this.ElementAt(this.Size()-1);
        }
    }
}
