using NUnit.Framework;
using OOPGDC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPGDC.Card;

namespace OOP21
{
    [TestFixture]
    class TestHand
{
        private Hand hand;

        [SetUp]
        public void InitHand()
        {
            this.hand = new HandImpl();
        }

        [Test]
        public void TestAddCard()
        {
            for (int i = 0; i <= 50; i++)
            {
                Card card = new CardImpl();
                Assert.IsTrue(this.hand.AddCard(card));
                Assert.AreEqual(this.hand.GetCard(i), card);
                Assert.AreEqual(this.hand.Size(), i + 1);
            }
        }

        [Test]
        public void TestRemoveCard()
        {
            for (int i = 0; i <= 50; i++)
            {
                Card card = new CardImpl();
                this.hand.AddCard(card);
                Assert.AreEqual(this.hand.Size(), 1);
                Assert.IsTrue(this.hand.RemoveCard(card));
                Assert.AreEqual(this.hand.Size(), 0);
            }
        }

        [Test]
        public void TestCalculatePoints()
        {
            Card card = new CardImpl(5);
            for (int i = 0; i <= 50; i++)
            {
                this.hand.AddCard(card);
                this.hand.CalculatePoints();
                Assert.AreEqual(this.hand.GetBlackJackPoints(), card.GetValue() * (i + 1));
            }

            this.hand = new HandImpl();
            Card ace = new CardImpl(1);
            for (int i = 0; i < 10; i++)
            {
                this.hand.AddCard(ace);
                this.hand.CalculatePoints();
                Assert.AreEqual(this.hand.GetBlackJackPoints(), 11 + (1 * i));
            }

            this.hand = new HandImpl();
            Card king = new CardImpl(13);
            for (int i = 0; i < 10; i++)
            {
                this.hand.AddCard(king);
                this.hand.CalculatePoints();
                Assert.AreEqual(10 * (i + 1), this.hand.GetBlackJackPoints());
            }
        }

        [Test]
        public void TestGetters()
        {
            this.hand = new HandImpl();
            Card card = new CardImpl(Suits.DIAMONDS, 5);
            Card card2 = new CardImpl(Suits.HEARTS, 10);
            this.hand.AddCard(card);
            this.hand.AddCard(card2);
            Assert.AreEqual(this.hand.GetCard(0), card);
            Assert.AreEqual(this.hand.GetLastCard(), card2);
            this.hand.CalculatePoints();
            Assert.AreEqual(this.hand.GetBlackJackPoints(), 15);
            Assert.AreEqual(this.hand.GetHand(), this.hand);
            Assert.AreEqual(this.hand.Size(), 2);
        }
    }
}
