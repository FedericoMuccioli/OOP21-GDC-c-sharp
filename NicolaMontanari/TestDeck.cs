using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using OOPGDC;
using static OOPGDC.Card;

namespace OOP21
{
    /// <summary>
    /// Test for Deck class.
    /// </summary>
    [TestFixture]
    public class TestDeck
    {
        private Deck Deck;
        private int Ndeck;
        [SetUp]
        public void InitDeck()
        {
            this.Deck = new DeckImpl(6);
        }

        private void GenerateDeck(int i)
        {
            this.Ndeck = i;
            this.Deck = new DeckImpl(this.Ndeck);
            this.Deck.GenerateDeck();
            this.Deck.Shuffle();
        }



        private int ChecknCardContained(Card c)
        {
            ArrayList List = (ArrayList) this.Deck;
            int k = 0;
            for (int i = 0; i < this.Deck.Size(); i++)
            {
                Card Card = (Card)List[i];
                if ((Card.GetCard().Item2 == c.GetCard().Item2
                        && (Card.GetSuit() == c.GetSuit())))
                {
                    k++;
                }
            }
            return k;
        }


        [Test]
        public void TestGenerateDeck()
        {
            for (int i = 0; i <= 25; i++)
            {
                GenerateDeck(i);
                Assert.AreEqual(this.Ndeck * 13 * 4, this.Deck.Size());
            }
        }

        [Test]
        public void TestShuffle()
        {
            GenerateDeck(6);
            this.Deck.DrawRandomCard();
            Assert.IsTrue(this.Deck.RemoveRandomCard());
            Assert.AreEqual(this.Deck.Size(), (this.Ndeck * 13 * 4) - 2);
            this.Deck.Shuffle();
            Assert.AreEqual(this.Deck.Size(), Ndeck * 13 * 4);
        }

        [Test]
        public void TestRemoveCards()
        {
            GenerateDeck(6);
            Assert.AreEqual(this.Deck.Size(), (Ndeck * 13 * 4));
            Assert.IsTrue(this.Deck.RemoveRandomCard());
            Assert.AreEqual(this.Deck.Size(), (Ndeck * 13 * 4) - 1);
            Assert.IsTrue(this.Deck.RemoveRandomCard());
            Assert.AreEqual(this.Deck.Size(), (Ndeck * 13 * 4) - 2);
            GenerateDeck(6);
            Card cardremoved = new CardImpl(Suits.DIAMONDS, 11);
            for (int i = 0; i <= 5; i++)
            {
                Assert.IsTrue(this.Deck.RemovePreciseCard(cardremoved));
                Assert.AreEqual(this.Deck.Size(), (Ndeck * 13 * 4) - i - 1);
                Assert.AreEqual(ChecknCardContained(cardremoved), 5 - i);
            }
            Assert.IsFalse(this.Deck.RemovePreciseCard(cardremoved));
            Assert.AreEqual(ChecknCardContained(cardremoved), 0);
            Assert.AreEqual(this.Deck.Size(), (Ndeck * 13 * 4) - 6);
        }

        [Test]
        public void TestDrawCards()
        {
            GenerateDeck(6);
            Assert.AreEqual(this.Deck.Size(), (Ndeck * 13 * 4));
            this.Deck.DrawRandomCard();
            Assert.AreEqual(this.Deck.Size(), (Ndeck * 13 * 4) - 1);
            this.Deck.DrawRandomCard();
            Assert.AreEqual(this.Deck.Size(), (Ndeck * 13 * 4) - 2);
            GenerateDeck(6);
            Card cardremoved = new CardImpl(Suits.DIAMONDS, 11);
            for (int i = 0; i <= 5; i++)
            {
                Card card2 = this.Deck.DrawPreciseCard(cardremoved);
                Assert.AreEqual(card2.GetSuit(), Suits.DIAMONDS);
                Assert.AreEqual(card2.GetCard().Item2, 11);
                Assert.AreEqual(this.Deck.Size(), (Ndeck * 13 * 4) - i - 1);
                Assert.AreEqual(ChecknCardContained(cardremoved), 5 - i);
            }
            Assert.AreEqual(this.Deck.DrawPreciseCard(cardremoved), null);
            Assert.AreEqual(ChecknCardContained(cardremoved), 0);
            Assert.AreEqual(this.Deck.Size(), (Ndeck * 13 * 4) - 6);
        }


    }
}
