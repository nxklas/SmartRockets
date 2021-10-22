using SmartRockets.Game.Abstracts;
using System.Collections.Generic;

namespace SmartRockets.Game
{
    internal sealed class DefaultEvaluator : EvaluatorBase
    {
        public DefaultEvaluator() : base()
        {
        }

        public override IList<Rocket> Evaluate(Rocket[] _rockets)
        {
            double maxFit = 0;
            List<Rocket> _matingPool = new();
            for (int i = 0; i < _rockets.Length; i++)
            {
                double currentFit = _rockets[i].Fitness;
                if (currentFit > maxFit)
                    maxFit = currentFit;
            }

           for (int i = 0; i < _rockets.Length; i++)
                _rockets[i].NormalizeFitness(maxFit);

            System.Diagnostics.Debug.WriteLine("max fitness: " + maxFit);

            for (int i = 0; i < _rockets.Length; i++)
            {
                double n = _rockets[i].Fitness * 100;

                for (int j = 0; j < n; j++)
                    _matingPool.Add(_rockets[i]);
            }
            return _matingPool;
        }
    }
}
