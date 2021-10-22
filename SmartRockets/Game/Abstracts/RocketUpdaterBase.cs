using System.Collections.Generic;

namespace SmartRockets.Game.Abstracts
{
    internal abstract class RocketUpdaterBase :IUpdater
    {
        protected IEnumerable<Rocket> _rockets;

        protected RocketUpdaterBase(IEnumerable<Rocket> rockets)
        {
            _rockets = rockets;
        }

        public abstract void Update(int gene);
    }
}
