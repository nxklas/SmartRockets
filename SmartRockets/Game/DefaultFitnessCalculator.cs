using static SmartRockets.Helpers.Mapper;
using SmartRockets.Game.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SmartRockets.Game
{
    internal sealed class DefaultFitnessCalculator : FitnessCalculatorBase
    {
        private Vector2 _targetLoc;
        private IList<Vector2> _obstacles;
        private int _windowWidth;

        public DefaultFitnessCalculator(IEnumerable<Rocket> rockets, Vector2 targetLoc, IEnumerable<Vector2> obstacles, int windowWidth) : base(rockets)
        {
            _targetLoc = targetLoc;
            _obstacles = obstacles.ToList();
            _windowWidth = windowWidth;
        }

        public override void Calc()
        {
            foreach (Rocket current in _rockets)
            {
                int i;
                for (i = 0; i < _obstacles.Count(); i++)
                    if (current.Position.Y < _obstacles[i].Y)
                    {
                        if (i == 0)
                            i++;
                        break;
                    }
                i++;
                double obstaclePassedValue = i * 100;
                double dist = Map(Vector2.Distance(current.Position, _targetLoc), 0.1, _windowWidth, _windowWidth, 0.1);

                if (current.HasCompleted())
                {
                    dist *= 10;
                }
                else if (current.HasCrashed())
                {
                    dist /= 10;
                }
                current.SetFitness(dist + obstaclePassedValue *(current.IsWinner? 20: 1));
            }
        }
    }
}
