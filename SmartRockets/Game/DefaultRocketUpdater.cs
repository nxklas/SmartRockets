using SmartRockets.Game.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SmartRockets.Game
{
    internal sealed class DefaultRocketUpdater : RocketUpdaterBase
    {
        private Vector2 _targetLoc;
        private IEnumerable<Vector2> _obstacleLocs;
        private int _width;
        private int _height;

        public DefaultRocketUpdater(IEnumerable<Rocket> rockets, Vector2 targetLoc, IEnumerable<Vector2> obstacleLocs, int windowWidth, int windowHeight) : base(rockets)
        {
            _targetLoc = targetLoc;
            _obstacleLocs = obstacleLocs;
            _width = windowWidth;
            _height = windowHeight;
        }

        public override void Update(int gene)
        {
            foreach (Rocket current in _rockets)
            {
                double dist = Vector2.Distance(current.Position, _targetLoc);

                if (dist < (Target.Width+Target.Height)/2)
                {
                    current.SetComplted(Rocket.DoneReason.Goal);
                    current.SetPos(_targetLoc);
                    System.Diagnostics.Debug.WriteLine("goal reached");
                }
                foreach (var currentObstacle in _obstacleLocs)
                {
                    if (current.Position.X > currentObstacle.X && current.Position.X < currentObstacle.X + GameManager.ObstacleWidth &&
                current.Position.Y > currentObstacle.Y && current.Position.Y < currentObstacle.Y + GameManager.ObstacleHeight)
                        current.SetCrashed(Rocket.DoneReason.Obstacle);
                }

                if (current.Position.X < 0 || current.Position.X + current.Width > _width || current.Position.Y < 0 || current.Position.Y + current.Height > _height)
                    current.SetCrashed(Rocket.DoneReason.Border);

                current.ApplyForce(current.Dna.Genes[gene]);
                if (!current.HasCompleted() && !current.HasCrashed())
                {
                    current.Vel += current.Acc;
                    current.SetPos(current.Position + current.Vel);
                    current.Acc *= 0;
                }
            }
        }
    }
}
