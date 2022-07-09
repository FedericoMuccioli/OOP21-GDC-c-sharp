using System.Drawing;

namespace GDC
{
    /// <summary>
    /// A roulette number that explicitly contains the number and color and provides if it contains a specific properties.
    /// </summary>
    public interface IRouletteNumber
    {
        /// <summary>
        /// Returns the value of the roulette number.
        /// </summary>
        /// <returns>the value of the roulette number</returns>
        int Value { get; }

        /// <summary>
        /// Returns the color of the roulette number.
        /// </summary>
        /// <return>gives the value of the roulette number</return>
        Color Color { get; }

        /// <summary>
        /// Returns if the specific property is included in the roulette number.
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="property"></param>
        /// <returns>returns true if the specific property is included in the roulette number, false otherwise.</
        bool IsProperty<P>(P property);
    }

}