using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace GDC
{
    /// <summary>
    /// The basic roulette wheel.
    /// </summary>
    public class BaseWheel : IWheel
    {
        private readonly IList<IRouletteNumber> _rouletteNumbers;

        /// <summary>
        /// Builds a basic roulette wheel with 37 numbers, 1 number green (0), 18 numbers red and 18 numbers black.
        /// </summary>
        public BaseWheel()
        {
            _rouletteNumbers = new List<IRouletteNumber>();
            _rouletteNumbers.Add(new BaseRouletteNumber(0, Color.Green));
            this._rouletteNumbers.Add(new BaseRouletteNumber(1, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(2, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(3, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(4, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(5, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(6, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(7, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(8, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(9, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(10, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(11, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(12, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(13, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(14, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(15, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(16, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(17, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(18, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(19, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(20, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(21, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(22, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(23, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(24, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(25, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(26, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(27, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(28, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(29, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(30, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(31, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(32, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(33, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(34, Color.Red));
            this._rouletteNumbers.Add(new BaseRouletteNumber(35, Color.Black));
            this._rouletteNumbers.Add(new BaseRouletteNumber(36, Color.Red));
        }

        /// <summary>
        /// Return the list of the roulette numbers.
        /// </summary>
        /// <returns>the list of the roulette numbers</returns>
        public IList<IRouletteNumber> GetList()
        {
            return _rouletteNumbers;
        }
    }
}