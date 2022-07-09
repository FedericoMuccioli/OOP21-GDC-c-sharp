namespace GDC
{
    /// <summary>
    /// Define the properties of the roulette numbers.
    /// </summary>
    public interface Property
    {
        /// <summary>
        /// The parity of a number.
        /// </summary>
        enum Parity
        {
            EVEN, ODD, NEUTRAL
        }

        /// <summary>
        /// Inclusion of a number.
        /// </summary>
        enum Included
        {
            _1_18_, _19_36_, NOT
        }

        /// <summary>
        /// Row of a number.
        /// </summary>
        enum Row
        {
            FIRST, SECOND, THIRD, NOT
        }

        /// <summary>
        /// Column of a number.
        /// </summary>
        enum Column
        {
            FIRST, SECOND, THIRD, NOT
        }

        /// <summary>
        /// Sector of a number.
        /// </summary>
        enum Sector
        {
            TIER, ORPHELINS, VOISINS, ZERO
        }
    }

}