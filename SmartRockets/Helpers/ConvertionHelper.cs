using SmartRockets.Game;
using System.Collections.Generic;
using System.Numerics;

namespace SmartRockets.Helpers
{
    /// <summary>
    /// Provides functionalities to simplify conversions
    /// </summary>
    internal static class ConvertionHelper
    {
        /// <summary>
        /// Extracts only the position of an <see cref="Obstacle"/> instance in an <see cref="IEnumerable{Obstacle}"/> (of <see cref="Obstacle"/>s) and stores it in an <see cref="IEnumerable{Vector2}"/> (of <see cref="Vector2"/>s)
        /// </summary>
        /// <param name="obstalces">The enumeration where to extract the position of the content from</param>
        /// <returns>An <see cref="IEnumerable{Obstacle}"/> (of <see cref="Obstacle"/>s) which contains the extracted positions (as <see cref="Vector2"/> instances)</returns>
        public static IEnumerable<Vector2> ExtractLocation(this IEnumerable<Obstacle> obstalces)
        {
            IList<Vector2> positions = new List<Vector2>();
            foreach (Obstacle current in obstalces)
                positions.Add(current.Loc);
            return positions;
        }
    }
}
