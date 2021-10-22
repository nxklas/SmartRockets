using static SmartRockets.Helpers.RandomProvider;
using System.Numerics;
using System;

namespace SmartRockets.Helpers
{
    /// <summary>
    /// Provides functionalities to simplify manipulating <see cref="Vector2"/> structs
    /// </summary>
    internal static class Vector2Helper
    {
        /// <summary>
        /// Represents a value that converts an angle in degreese to a radian angle
        /// </summary>
        public const double DegToRad = Math.PI / 180.0;
        /// <summary>
        /// Represents a value that converts an angle in radian to a degreese angle
        /// </summary>
        public const double RadToDeg = 180.0 / Math.PI;

        /// <summary>
        /// Creates a random-generated <see cref="Vector2"/> instance
        /// </summary>
        /// <returns>The random-generated <see cref="Vector2"/> instance</returns>
        public static Vector2 Random2D()
        {
            float length = 1;
            double angle = Rand.NextDouble() * (2 * Math.PI);

            return new Vector2(length * (float)Math.Cos(angle), length * (float)Math.Sin(angle));
        }

        /// <summary>
        /// Gets the angle of rotation form a <see cref="Vector2"/> instance
        /// </summary>
        /// <param name="vector">The vector where to get the angle from</param>
        /// <param name="inDegrees">Indicates whether to get the angle as degrees (otherwise, radians)</param>
        /// <returns>The anlge of rotation</returns>
        public static double GetHeading(this Vector2 vector, bool inDegrees = true) =>
            inDegrees ? RadianToDegrees(Math.Atan2(vector.Y, vector.X)) : Math.Atan2(vector.Y, vector.X);

        /// <summary>
        /// Gets the magnitude (or length) from a <see cref="Vector2"/> instance
        /// </summary>
        /// <param name="vector">The vector where to get the magnitude from</param>
        /// <returns>The magnitude of the vector</returns>
        public static double GetMag(this Vector2 vector) => Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

        /// <summary>
        /// Sets the magnitude (or length) of a <see cref="Vector2"/> instance
        /// </summary>
        /// <param name="vector">The vector where to set the magnitude from</param>
        /// <param name="mag">The magnitude value</param>
        /// <returns>The vector with the new magnitude</returns>
        public static Vector2 SetMag(this Vector2 vector, double mag) => new((float)(vector.X * mag / vector.GetMag()), (float)(vector.Y * mag / vector.GetMag()));

        /// <summary>
        /// Converts angles from radian to degrees
        /// </summary>
        /// <param name="angle">The angle to convert (in radians)</param>
        /// <returns>The converted degrees-angle</returns>
        public static double RadianToDegrees(double angle) => angle * RadToDeg;

        /// <summary>
        /// Converts angles from degrees to radian
        /// </summary>
        /// <param name="angle">The angle to convert (in degrees)</param>
        /// <returns>The converted radian-angle</returns>
        public static double DegreesToRadian(double angle) => angle * DegToRad;
    }
}
