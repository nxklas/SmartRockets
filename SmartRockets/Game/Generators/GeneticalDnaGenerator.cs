using static SmartRockets.Helpers.RandomProvider;
using SmartRockets.Game.Abstracts;
using System.Numerics;

namespace SmartRockets.Game.Generators
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class GeneticalDnaGenerator : DnaGeneratorBase
    {
        private readonly Dna _mother;
        private readonly Dna _father;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lifespan"></param>
        public GeneticalDnaGenerator(int lifespan, Dna mother, Dna father):base(lifespan)
        {
            _mother = mother;
            _father = father;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lifespan"></param>
        /// <returns></returns>
        protected override Dna Generate(int lifespan)
        {
            Vector2[] newGenes = new Vector2[lifespan];
            double mid = System.Math.Floor((double)Rand.Next(0, lifespan));

            for (int i = 0; i < lifespan; i++)
            {
                if (i > mid)
                {
                    newGenes[i] = _mother.Genes[i];
                }
                else
                {
                    newGenes[i] = _father.Genes[i];
                }
            }

            return new(newGenes);
        }
    }

    
}
