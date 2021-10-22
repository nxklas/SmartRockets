using System;

namespace SmartRockets.Helpers
{
    /// <summary>
    /// Provides a global pseudo-random number generator. This class cannot be inherited. This class is not instantiable
    /// </summary>
    internal static class RandomProvider
    {
        private static Random _random = new();

        /// <summary>
        /// Represents a globally accessible <see cref="Random"/> instance
        /// </summary>
        public static Random Rand => _random;
    }
}
