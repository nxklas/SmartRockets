using SmartRockets.Game.Abstracts;
using System.Linq;

namespace SmartRockets.Game.Generators
{
    /// <summary>
    /// Represents the default rocket generator which randomly generates rocket's DNAs
    /// </summary>
    internal sealed class RandomizedRocketGenerator : RocketGeneratorBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RandomizedRocketGenerator"/> class
        /// </summary>
        /// <param name="rocketCount">The amount of rockets to generate</param>
        public RandomizedRocketGenerator(int rocketCount, int lifepan,int x,int y) : base(rocketCount,lifepan, x, y)
        {
        }

        /// <summary>
        /// Generates an array of <see cref="Rocket"/>s whose DNAs are random-generated
        /// </summary>
        /// <param name="rocketCount">The amount of rockets to generate</param>
        /// <returns>The generated <see cref="Rocket"/>[]</returns>
        protected override Rocket[] Generate(int rocketCount)
        {
            Rocket[] rockets = new Rocket[rocketCount];
            for (int i = 0; i < rocketCount; i++)
                rockets[i] = new Rocket(_x,_y,Width, Height,new RandomizedDnaGenerator(_lifespan).Generate());
            return rockets;
        }
    }
}
