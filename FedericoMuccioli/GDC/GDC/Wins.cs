using System;
using System.Collections.Generic;
using System.Drawing;
using static GDC.Property;

namespace GDC
{
    /// <summary>
    /// Calculate the win of roulette game.
    /// </summary>
    public class Wins
    {
        public static readonly double NUMBER_PAYOUT = 36.0;
        public static readonly double COLOR_PAYOUT = 2.0;
        public static readonly double PARITY_PAYOUT = 2.0;
        public static readonly double INCLUDED_PAYOUT = 2.0;
        public static readonly double COLUMN_PAYOUT = 3.0;
        public static readonly double ROW_PAYOUT = 3.0;
        public static readonly double ZERO_PAYOUT = 36.0 / 7;
        public static readonly double VOISINS_PAYOUT = 36.0 / 17;
        public static readonly double TIER_PAYOUT = 36.0 / 12;
        public static readonly double ORPHELINS_PAYOUT = 36.0 / 8;

        /// <summary>
        /// Calculates the payout given a list of bets (a pair of object(property) and double(bet) and the winning number.
        /// </summary>
        /// <param name="bets"></param>
        /// <param name="winningNumber"></param>
        /// <returns>the win's value</returns>
        public double Win(IList<Tuple<Object, Double>> bets, IRouletteNumber winningNumber)
        {
            double win = 0.0;
            foreach (var p in bets)
            {
                Object property = p.Item1;
                double amount = p.Item2;

                if (winningNumber.IsProperty(property))
                {
                    if (property is int)
                    {
                        win += amount * NUMBER_PAYOUT;
                    }
                    else if (property is Color)
                    {
                        win += amount * COLOR_PAYOUT;
                    }
                    else if (property is Parity)
                    {
                        win += amount * PARITY_PAYOUT;
                    }
                    else if (property is Included)
                    {
                        win += amount * INCLUDED_PAYOUT;
                    }
                    else if (property is Column)
                    {
                        win += amount * COLUMN_PAYOUT;
                    }
                    else if (property is Row)
                    {
                        win += amount * ROW_PAYOUT;
                    }
                    else if (property is Sector)
                    {
                        switch (property)
                        {
                            case Sector.ZERO:
                                win += amount * ZERO_PAYOUT;
                                break;
                            case Sector.VOISINS:
                                win += amount * VOISINS_PAYOUT;
                                break;
                            case Sector.TIER:
                                win += amount * TIER_PAYOUT;
                                break;
                            case Sector.ORPHELINS:
                                win += amount * ORPHELINS_PAYOUT;
                                break;
                        }
                    }
                }
            }
            win = Math.Round(win, 2);
            return win;
        }
    }
}