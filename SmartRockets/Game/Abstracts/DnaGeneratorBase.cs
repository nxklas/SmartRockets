namespace SmartRockets.Game.Abstracts
{
    /// <summary>
    /// Represents the base class for <see cref="Dna"/> generators
    /// </summary>
    internal abstract class DnaGeneratorBase : IGenerator<Dna>
    {
        private int _lifespan;

        /// <summary>
        /// Initializes a new instance of <see cref="DnaGeneratorBase"/> class
        /// </summary>
        /// <param name="lifespan">The lifespan of the owner</param>
        protected DnaGeneratorBase(int lifespan)
        {
            if (lifespan < 1)
                throw new System.ArgumentException($"The value of {nameof(lifespan)} was too small. The value must be 0 or greater, actual value: {lifespan}",
                            nameof(lifespan));
            _lifespan = lifespan;
        }

        /// <summary>
        /// Represents the lifespan of the owner of the current <see cref="Dna"/>
        /// </summary>
        public int Lifespan
        {
            get => _lifespan;
            set
            {
                if (value < 1)
                    throw new System.ArgumentException($"Could not change the value of {nameof(Lifespan)}. The value must be 0 or greater, actual value: {value}",
                        nameof(value));
                _lifespan = value;
            }
        }

        /// <summary>
        /// Generates a <see cref="Dna"/> using the implemented algorithm
        /// </summary>
        /// <returns>The generated <see cref="Dna"/></returns>
        public Dna Generate() => Generate(_lifespan);

        /// <summary>
        /// Generates a <see cref="Dna"/>
        /// </summary>
        /// <param name="lifespan">The lifespan of the owner</param>
        /// <returns>The generated <see cref="Dna"/></returns>
        protected abstract Dna Generate(int lifespan);
    }
}
