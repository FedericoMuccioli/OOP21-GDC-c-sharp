namespace GDC
{
    /// <summary>
    /// Roulette's factory.
    /// </summary>
    public interface IRouletteFactory
    {
        /// <summary>
        /// Create and return a base roulette with 37 numbers.
        /// </summary>
        /// <returns>create and return a base roulette</returns>
        IRoulette CreateBaseRoulette();

    }
}