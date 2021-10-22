using static SmartRockets.Helpers.RandomProvider;
using SmartRockets.Game.Abstracts;
using System.Collections.Generic;

namespace SmartRockets.Game.Generators
{
    internal sealed class GeneticRocketGenerator : RocketGeneratorBase
    {
        private Rocket[] _lastGeneration;
        private IList<Rocket> _matingPool;

        public GeneticRocketGenerator(int rocketCount, int lifepan, int x, int y, Rocket[] lastGeneration, EvaluatorBase evaluator) : base(rocketCount, lifepan, x, y)
        {
            _lastGeneration = lastGeneration;
            _matingPool = evaluator.Evaluate(lastGeneration);
        }

        protected override Rocket[] Generate(int rocketCount)
        {
            var newRockets = new Rocket[rocketCount];
            for (int i = 0; i < _lastGeneration.Length; i++)
            {
                var parentA = _matingPool[Rand.Next(0, _matingPool.Count)];
                var parentB = _matingPool[Rand.Next(0, _matingPool.Count)];
                _matingPool.Remove(parentA);
                _matingPool.Remove(parentB);
                var child = new GeneticalDnaGenerator(GameManager.Lifespan, parentA.Dna, parentB.Dna).Generate();
                child.Mutate();
                newRockets[i] = new Rocket(_x, _y, Width, Height,child);
            }
            return newRockets;
        }
    }
}
