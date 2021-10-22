using System;

namespace SmartRockets.Helpers
{
    /// <summary>
    /// Provides functionalities to map values
    /// </summary>
    internal static class Mapper
    {
        /// <summary>
        /// Re-maps a value from one range to another
        /// </summary>
        /// <param name="value">The value to be re-mapped</param>
        /// <param name="start1">The lower bound of the value's current range</param>
        /// <param name="stop1">The upper bound of the value's current range</param>
        /// <param name="start2">The lower bound of the value's target range</param>
        /// <param name="stop2">The upper bound of the value's target range</param>
        /// <param name="withinBounds">Indicates whether to constrain the value to the newly mapped range</param>
        /// <returns>The remapped value</returns>
        public static double Map(double value, double start1, double stop1, double start2, double stop2, bool withinBounds = false)
        {
            double newValue = (value - start1) / (stop1 - start1) * (stop2 - start2) + start2;

            if (!withinBounds)
                return newValue;
            return start2 < stop2 ? Constrain(newValue, start2, stop2) : Constrain(newValue, stop2, start2);
        }

        /// <summary>
        /// Constrains a value between a minimum and maximum value
        /// </summary>
        /// <param name="value">The value to be constrained</param>
        /// <param name="low">The minimum limit</param>
        /// <param name="high">The maximum limit</param>
        /// <returns>The constrained value</returns>
        public static double Constrain(double value, double low, double high) => Math.Max(Math.Min(value, high), low);
    }
}
