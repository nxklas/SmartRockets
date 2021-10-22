namespace SmartRockets.Game.Abstracts
{
    /// <summary>
    /// Represents the base class for <see cref="Rocket"/>[] generators
    /// </summary>
    internal abstract class RocketGeneratorBase : IGenerator<Rocket[]>
    {
        private int _count;
        /// <summary>
        /// The lifespan of each rocket
        /// </summary>
        protected int _lifespan;
        protected int _x;
        protected int _y;
        /// <summary>
        /// The width of each rocket
        /// </summary>
        public const int Width=10;
        /// <summary>
        /// The height of each rocket
        /// </summary>
        public const int Height = 30;

        /// <summary>
        /// Initializes a new instance of <see cref="RocketGeneratorBase"/> class
        /// </summary>
        /// <param name="rocketCount">The amount of rockets to generate</param>
        /// <param name="lifespan">The lifespan of the rockets to generate</param>
        /// <param name="rocketWidth">The width of each rocket</param>
        /// <param name="rocketHeight">The height of each rocket</param>
        protected RocketGeneratorBase(int rocketCount,int lifespan,int x,int y)
        {
            if (rocketCount < 1)
                throw new System.ArgumentException($"The value of {nameof(rocketCount)} was too small. The value must be 0 or greater, actual value: {rocketCount}",
                    nameof(rocketCount));
            _count = rocketCount;
            if (lifespan < 1)
                throw new System.ArgumentException($"The value of {nameof(lifespan)} was too small. The value must be 0 or greater, actual value: {lifespan}",
                            nameof(lifespan));
            _lifespan = lifespan;
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Represents the amount of rockets to generate
        /// </summary>
        public int RocketCount
        {
            get => _count;
            set
            {
                if (value < 1)
                    throw new System.ArgumentException($"Could not change the value of {nameof(RocketCount)}. The value must be 0 or greater, actual value: {value}",
                        nameof(value));
                _count = value;
            }
        }

        /// <summary>
        /// Generates a <see cref="Rocket"/>[] using the implemented algorithm
        /// </summary>
        /// <returns>The generated <see cref="Rocket"/>[]</returns>
        public Rocket[] Generate() => Generate(_count);

        /// <summary>
        /// Generates a <see cref="Rocket"/>[]
        /// </summary>
        /// <param name="rocketCount">The amount of rockets to generate</param>
        /// <returns>The generated <see cref="Rocket"/>[]</returns>
        protected abstract Rocket[] Generate(int rocketCount);
    }
}
