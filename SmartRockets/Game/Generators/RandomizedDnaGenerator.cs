using SmartRockets.Game.Abstracts;
using System;

namespace SmartRockets.Game.Generators
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class RandomizedDnaGenerator : DnaGeneratorBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lifespan"></param>
        public RandomizedDnaGenerator(int lifespan) : base(lifespan)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lifespan"></param>
        /// <returns></returns>
        protected override Dna Generate(int lifespan)=>new Dna(lifespan);
    }
}
