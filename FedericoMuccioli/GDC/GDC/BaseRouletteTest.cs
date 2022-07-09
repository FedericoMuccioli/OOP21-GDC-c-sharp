using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using static GDC.Property;

namespace GDC
{
    public class BaseRouletteTest
    {
        private static readonly int TESTCASE = 1000;
        private readonly IRoulette _roulette = new RouletteFactoryImpl().CreateBaseRoulette();
        private readonly IWheel _wheel = new WheelFactoryImpl().CreateBaseWheel();
        private readonly Wins _wins = new();
        private List<Tuple<Object, Double>> _bets;
        private Double _amountBet;

        [SetUp]
        public void Setup()
        {
            _bets = new List<Tuple<object, double>>();
            _amountBet = 1.00;
        }

        // test if the roulette returns a number between 0 and 36 in 1000 cases
        [Test]
        public void TestValidWinningNumber()
        {
            for (int i = 0; i < TESTCASE; i++)
            {
                int n = _roulette.Spin().Value;
                Assert.True(n >= 0 && n <= 36);
            }
        }

        // test if roulette returns all 37 numbers in 1000 cases
        [Test]
        public void TestValidIntervalWinningNumber()
        {
            IList valuesWinningNumbers = new List<int>();
            for (int i = 0; i < TESTCASE; i++)
            {
                int n = _roulette.Spin().Value;
                if (!valuesWinningNumbers.Contains(n))
                {
                    valuesWinningNumbers.Add(n);
                }
            }
            Assert.AreEqual(valuesWinningNumbers.Count, 37);
        }

        // test the pay on the number
        [Test]
        public void TestNumberBet()
        {
            // I bet on 0 and the winning number is zero, I win 36
            Int32 betNumber = 0;
            _bets.Add(new Tuple<Object, Double>(betNumber, _amountBet));
            Assert.AreEqual(_amountBet * 36, _wins.Win(_bets, _wheel.GetList()[0]));

            // I bet on 0 and the winning number is 1, I lose the bet
            Assert.AreEqual(0, _wins.Win(_bets, _wheel.GetList()[1]));

            // I bet all the numbers but only 0 will win I win once the bet * 36
            for (betNumber++; betNumber < 38; betNumber++)
            {
                _bets.Add(new Tuple<Object, Double>(betNumber, _amountBet));
            }
            Assert.AreEqual(36, _wins.Win(_bets, _wheel.GetList()[0]));

            // I bet 2.22eur on the winning number
            betNumber = 0;
            _amountBet = 2.22;
            _bets = new List<Tuple<Object, Double>>();
            _bets.Add(new Tuple<Object, Double>(betNumber, _amountBet));
            Assert.AreEqual(_amountBet * 36, _wins.Win(_bets, _wheel.GetList()[betNumber]));
        }

        // test the pay on the color
        [Test]
        public void TestColorBet()
        {
            // I bet on red and text win on all red numbers and loss on all others
            Color winProperty = Color.Black;
            _bets.Add(new Tuple<Object, Double>(winProperty, _amountBet));
            foreach (IRouletteNumber rouletteNumber in _wheel.GetList())
            {
                if (rouletteNumber.IsProperty(winProperty))
                {
                    Assert.AreEqual(_amountBet * 2, _wins.Win(_bets, rouletteNumber));
                }
                else
                {
                    Assert.AreEqual(0, _wins.Win(_bets, rouletteNumber));
                }
            }

            // I bet on red and black but zero comes out (neutral)
            _bets.Add(new Tuple<Object, Double>(Color.Red, _amountBet));
            Assert.AreEqual(0, _wins.Win(_bets, _wheel.GetList()[0]));
        }

        // test the pay on parity
        [Test]
        public void TestParityBet()
        {
            // I bet on even numbers and test the win on all even numbers and the loss on all others
            Parity winProperty = Parity.EVEN;
            _bets.Add(new Tuple<Object, Double>(winProperty, _amountBet));
            foreach (IRouletteNumber rouletteNumber in _wheel.GetList())
            {
                if (rouletteNumber.IsProperty(winProperty))
                {
                    Assert.AreEqual(_amountBet * 2, _wins.Win(_bets, rouletteNumber));
                }
                else
                {
                    Assert.AreEqual(0, _wins.Win(_bets, rouletteNumber));
                }
            }

            // I bet on even and odd but zero comes out (neutral)
            _bets.Add(new Tuple<Object, Double>(Parity.ODD, _amountBet));
            Assert.AreEqual(0, _wins.Win(_bets, _wheel.GetList()[0]));
        }

        // test the pay if numbers are included
        [Test]
        public void testNumberIncludedBet()
        {
            // I bet on the range 1.18 and test the winnings and losses of all numbers
            Included winProperty = Included._1_18_;
            _bets.Add(new Tuple<Object, Double>(winProperty, _amountBet));
            foreach (IRouletteNumber rouletteNumber in _wheel.GetList())
            {
                if (rouletteNumber.IsProperty(winProperty))
                {
                    Assert.AreEqual(_amountBet * 2, _wins.Win(_bets, rouletteNumber));
                }
                else
                {
                    Assert.AreEqual(0, _wins.Win(_bets, rouletteNumber));
                }
            }

            // I bet on the interval 1-18 and 19-36 but zero comes out (neutral)
            _bets.Add(new Tuple<Object, Double>(Included._19_36_, _amountBet));
            Assert.AreEqual(0, _wins.Win(_bets, _wheel.GetList()[0]));
        }

        // test the pay on the column
        [Test]
        public void TestColumnBet()
        {
            // I bet on the first column and text the winnings and losses on all numbers
            IList<IRouletteNumber> numbers = _wheel.GetList();
            Column winProperty = Column.FIRST;
            _bets.Add(new Tuple<Object, Double>(winProperty, _amountBet));
            foreach (IRouletteNumber rouletteNumber in numbers)
            {
                if (rouletteNumber.IsProperty(winProperty))
                {
                    Assert.AreEqual(_amountBet * 3, _wins.Win(_bets, rouletteNumber));
                }
                else
                {
                    Assert.AreEqual(0, _wins.Win(_bets, rouletteNumber));
                }
            }

            // I bet on the three properties but zero comes out (neutral)
            _bets.Add(new Tuple<Object, Double>(Column.SECOND, _amountBet));
            _bets.Add(new Tuple<object, double>(Column.THIRD, _amountBet));
            Assert.AreEqual(0, _wins.Win(_bets, numbers[0]));
        }

        // test the pay on the line
        [Test]
        public void TestRowBet()
        {
            // I bet on the first line and text the winnings and losses on all numbers
            IList<IRouletteNumber> numbers = _wheel.GetList();
            Row winProperty = Row.FIRST;
            _bets.Add(new Tuple<Object, Double>(winProperty, _amountBet));
            foreach (IRouletteNumber rouletteNumber in numbers)
            {
                if (rouletteNumber.IsProperty(winProperty))
                {
                    Assert.AreEqual(_amountBet * 3, _wins.Win(_bets, rouletteNumber));
                }
                else
                {
                    Assert.AreEqual(0, _wins.Win(_bets, rouletteNumber));
                }
            }
            // I bet on the three properties but zero comes out (neutral)
            _bets.Add(new Tuple<Object, Double>(Row.SECOND, _amountBet));
            _bets.Add(new Tuple<Object, Double>(Row.THIRD, _amountBet));
            Assert.AreEqual(0, _wins.Win(_bets, numbers[0]));

            //scommetto sulle tre proprietà ma esce il doppio zero(neutro)
            Assert.AreEqual(0, _wins.Win(_bets, numbers[0]));
        }
    }
}
