namespace SmartRockets.Game.Abstracts
{
    /// <summary>
    /// Represents a generator
    /// </summary>
    /// <typeparam name="T">The type of the object to generate</typeparam>
    internal interface IGenerator<T>
    {
        /// <summary>
        /// Generates an instance of <typeparamref name="T"/>
        /// </summary>
        /// <returns>The generated instance</returns>
        T Generate();
    }
}
