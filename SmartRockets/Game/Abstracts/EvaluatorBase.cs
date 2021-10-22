using System.Collections.Generic;
using System.Numerics;

namespace SmartRockets.Game.Abstracts
{
    internal abstract class EvaluatorBase : IEvaluator<Rocket>
    {
        protected EvaluatorBase()
        {
        }

        public abstract IList<Rocket> Evaluate(Rocket[] items);
    }
}
