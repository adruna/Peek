/* Author: Luke Familo */
using System.Linq;
using System.Drawing;

namespace Screener
{
    /// <summary>
    /// Extensions class, adds functionality to some underdeveloped microsoft classes.
    /// 
    /// Rectangle - get midpoint
    /// Point - multiple
    /// Size - multiple
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Calculates the midpoint of the rectangle.
        /// </summary>
        /// <returns> The midpoint. </returns>
        public static Point GetMidpoint(this Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
        }

        /// <summary>
        /// Returns a size object with both components multiplied by the given value.
        /// (non-volitial).
        /// </summary>
        /// <param name="mult"> Multiplier, the value to multiply by. </param>
        /// <returns> The multipled size object. </returns>
        public static Size Multiple(this Size size, double mult)
        {
            return new Size((int)(size.Width * mult), (int)(size.Height * mult));
        }

        /// <summary>
        /// Returns a point object with both components multiplied by the given value.
        /// (non-volitial).
        /// </summary>
        /// <param name="mult"> Multiplier, the value to multiply by. </param>
        /// <returns> The multipled point object. </returns>
        public static Point Multiple(this Point point, double mult)
        {
            return new Point((int)(point.X * mult), (int)(point.Y * mult));
        }

        /// <summary>
        /// Returns a basic array of the given type from the given <code>System.Array</code> object.
        /// (any objects not of the given type are not included).
        /// </summary>
        /// <typeparam name="T"> The type of array and objects to look for. </typeparam>
        /// <param name="array"> Extension this param. </param>
        /// <returns> Array of the given type of objects. </returns>
        public static T[] ToSimpleArray<T>(this System.Array array)
        {
            return array.OfType<T>().ToArray<T>();
        }
    }
}
