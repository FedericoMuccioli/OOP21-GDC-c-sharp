using System.Collections.Generic;
using System.Drawing;

namespace GDC
{
    internal delegate IList<IRouletteNumber> GetList();

    /// <summary>
    /// Wheel's factory, creates different type of wheel.
    /// </summary>
    public class WheelFactoryImpl : IWheelFactory
    {
        /// <summary>
        /// Creates a basic roulette wheel.
        /// </summary>
        /// <returns>a basic roulette wheel</returns>
        public IWheel CreateBaseWheel() => new BaseWheel();
    }

}