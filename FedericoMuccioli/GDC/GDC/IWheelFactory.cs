namespace GDC
{
    /// <summary>
    /// Wheel's factory.
    /// </summary>
    public interface IWheelFactory
    {
        /// <summary>
        /// Creates a basic roulette wheel.
        /// </summary>
        /// <returns>a basic roulette wheel</returns>
        IWheel CreateBaseWheel();

    }
}