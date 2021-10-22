using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRockets.Game.Abstracts
{
    internal abstract class FitnessCalculatorBase : ICalulator
    {
        protected IEnumerable<Rocket> _rockets;

        protected FitnessCalculatorBase(IEnumerable<Rocket> rockets)
        {
            _rockets = rockets;
        }

        public abstract void Calc();
    }
}
