using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRockets.Game.Abstracts
{
    internal interface IEvaluator<T>
    {
        public IList<T> Evaluate(T[] items);
    }
}
