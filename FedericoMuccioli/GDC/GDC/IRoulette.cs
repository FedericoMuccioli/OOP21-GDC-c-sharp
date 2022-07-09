namespace GDC
{
    /// <summary>
    /// A roulette that returns a roulette number.
    /// </summary>
    public interface IRoulette
    {
        /// <summary>
        /// Return a random roulette number contains in roulette.
        /// </summary>
        /// <returns>return a random roulette number contains in roulette</returns>
        IRouletteNumber Spin();
    }

}