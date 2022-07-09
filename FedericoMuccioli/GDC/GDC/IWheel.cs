using System.Collections.Generic;

namespace GDC
{
    /// <summary>
    /// The collection that contains the roulette numbers.
    /// </summary>
    public interface IWheel
    {
        /// <summary>
        /// Return the list of the roulette numbers.
        /// </summary>
        /// <returns>the list of the roulette numbers</returns>
        IList<IRouletteNumber> GetList();
    }
}