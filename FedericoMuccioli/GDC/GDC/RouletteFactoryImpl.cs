using System;
using System.Collections.Generic;

namespace GDC
{
    internal delegate IRouletteNumber Spin();

    /// <summary>
    /// Roulette's factory.
    /// </summary>
    public class RouletteFactoryImpl : IRouletteFactory
    {
        private readonly IWheelFactory _wheelFactory;
        private readonly Random _random;

        /// <summary>
        /// Create a roulette's factory.
        /// </summary>
        public RouletteFactoryImpl()
        {
            _wheelFactory = new WheelFactoryImpl();
            _random = new Random();
        }

        /// <summary>
        /// Create and return a base roulette with 37 numbers.
        /// </summary>
        /// <returns>create and return a base roulette</returns>
        public IRoulette CreateBaseRoulette()
        {
            IList<IRouletteNumber> baseNumbers = _wheelFactory.CreateBaseWheel().GetList();
            return new RouletteImpl(() => baseNumbers[_random.Next(baseNumbers.Count)]);
        }

        private class RouletteImpl : IRoulette
        {
            private readonly Spin _spin;

            public RouletteImpl(Spin spin)
            {
                _spin = spin;
            }

            public IRouletteNumber Spin()
            {
                return _spin();
            }
        }

    }
}