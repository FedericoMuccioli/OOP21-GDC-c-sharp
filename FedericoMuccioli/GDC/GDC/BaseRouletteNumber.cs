
using System;
using System.Drawing;
using static GDC.Property;

namespace GDC
{
    /// <summary>
    /// A roulette number containing the parity, inclusion, column, row as well as the number and color.
    /// </summary>
    public class BaseRouletteNumber : IRouletteNumber
    {
        /// <summary>
        /// Create a roulette number with the specific value and color.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="color"></param>
        public BaseRouletteNumber(int value, Color color)
        {
            Value = value;
            Color = color;
        }

        /// <summary>
        /// Returns the value of the roulette number.
        /// </summary>
        /// <returns>the value of the roulette number</returns>
        public int Value { get; }

        /// <summary>
        /// Returns the color of the roulette number.
        /// </summary>
        /// <return>gives the value of the roulette number</return>
        public Color Color { get; }

        /// <summary>
        /// Return the parity of the roulette number.
        /// </summary>
        /// <returns>return the parity of the roulette number</returns>
        public Parity GetParity() => Value == 0 ? Parity.NEUTRAL : Value % 2 == 0 ? Parity.EVEN : Parity.ODD;

        /// <summary>
        /// Return the included of the roulette number.
        /// </summary>
        /// <returns>return the included of the roulette number</returns>
        public Included GetIncluded() => Value == 0 ? Included.NOT : Value >= 1 && Value <= 18 ? Included._1_18_ : Included._19_36_;

        /// <summary>
        /// Return the column of the roulette number.
        /// </summary>
        /// <returns>return the column of the roulette number</returns>
        public Column GetColumn()
        {
            if (Value == 0)
            {
                return Column.NOT;
            }
            int nColumn = Value / 12;
            return nColumn <= 1 ? Column.FIRST : (nColumn <= 2 ? Column.SECOND : Column.THIRD);
        }

        /// <summary>
        /// Return the row of the roulette number.
        /// </summary>
        /// <returns>row the parity of the roulette number</returns>
        public Row GetRow()
        {
            if (Value == 0)
            {
                return Row.NOT;
            }
            int nRow = Value % 3;
            return nRow == 0 ? Row.FIRST : (nRow == 2 ? Row.SECOND : Row.THIRD);
        }

        /// <summary>
        /// Returns if the specific property is included in the roulette number.
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <param name="property"></param>
        /// <returns>returns true if the specific property is included in the roulette number, false otherwise.</returns
        public bool IsProperty<P>(P property)
        {
            if (property.Equals(Value))
            {
                return true;
            }
            else if (property.Equals(Color))
            {
                return true;
            }
            else if (property.Equals(GetParity()))
            {
                return true;
            }
            else if (property.Equals(GetIncluded()))
            {
                return true;
            }
            else if (property.Equals(GetColumn()))
            {
                return true;
            }
            else if (property.Equals(GetRow()))
            {
                return true;
            }
            return false;
        }

        public override String ToString()
        {
            return Value.ToString();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Color);
        }

        public override bool Equals(object obj)
        {
            return obj is BaseRouletteNumber number &&
                   Value == number.Value &&
                   Color.Equals(number.Color);
        }
    }
}