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
    /// <summary>
    /// Test for Card class.
    /// </summary>
    [TestFixture]
    class TestCard
    {
        private Card card;
        private readonly Card.Suits[] SuitsValues = (Suits[])Enum.GetValues(typeof(Suits));

        private Boolean CheckEnum(Suits s)
        {
            foreach (Suits suits in this.SuitsValues)
            {
                if (suits.ToString().Equals(s.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private static Boolean CheckPoints(int points)
        {
            return (points <= 10 && points > 0);
        }

        [Test]
        public void TestGenerateCard()
        {
            //carta random
            for (int i = 0; i <= 100; i++)
            {
                this.card = new CardImpl();
                Assert.IsTrue(CheckEnum(this.card.GetSuit()));
                Assert.IsTrue(CheckPoints(this.card.GetValue()));
                Assert.IsFalse(this.card.IsFaceDown());
            }
            //Seme preciso
            for (int i = 0; i <= 100; i++)
            {
                this.card = new CardImpl(Suits.DIAMONDS);
                Assert.IsTrue(Suits.DIAMONDS.ToString().Equals(this.card.GetSuit().ToString()));
                Assert.IsTrue(CheckPoints(this.card.GetValue()));
                Assert.IsFalse(this.card.IsFaceDown());
            }
            //Valore preciso
            for (int i = 0; i <= 100; i++)
            {
                this.card = new CardImpl(5);
                Assert.IsTrue(CheckEnum(this.card.GetSuit()));
                Assert.AreEqual(this.card.GetValue(), 5);
                Assert.IsFalse(this.card.IsFaceDown());
            }
            //carta random coperta
            for (int i = 0; i <= 100; i++)
            {
                this.card = new CardImpl(true);
                Assert.IsTrue(CheckEnum(this.card.GetSuit()));
                Assert.IsTrue(CheckPoints(this.card.GetValue()));
                Assert.IsTrue(this.card.IsFaceDown());
            }
            //carta precisa
            for (int i = 0; i <= 100; i++)
            {
                this.card = new CardImpl(Suits.DIAMONDS, 5);
                Assert.IsTrue(Suits.DIAMONDS.ToString().Equals(this.card.GetSuit().ToString()));
                Assert.AreEqual(this.card.GetValue(), 5);
                Assert.IsFalse(this.card.IsFaceDown());
            }
        }

        [Test]
        public void TestGetters()
        {
            //Uguale a carta precisa
            for (int i = 0; i <= 100; i++)
            {
                this.card = new CardImpl(Suits.DIAMONDS, 5);
                Assert.IsTrue(Suits.DIAMONDS.ToString().Equals(this.card.GetSuit().ToString()));
                Assert.AreEqual(this.card.GetValue(), 5);
                Assert.IsFalse(this.card.IsFaceDown());
            }
        }

        [Test]
        public void TestTurnOver()
        {
            //Uguale a carta precisa
            for (int i = 0; i <= 100; i++)
            {
                this.card = new CardImpl(Suits.DIAMONDS, 5);
                Assert.IsTrue(Suits.DIAMONDS.ToString().Equals(this.card.GetSuit().ToString()));
                Assert.AreEqual(this.card.GetValue(), 5);
                Assert.IsFalse(this.card.IsFaceDown());
                this.card.TurnOver();
                Assert.IsTrue(this.card.IsFaceDown());
            }
        }
    }
}
