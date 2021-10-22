using static SmartRockets.Helpers.ConvertionHelper;
using System.Collections.Generic;
using System.Drawing;

namespace SmartRockets.Game
{
    internal sealed class GameManager
    {
        public const double MaxForce = 0.2;
        public const int Lifespan = 250;
        public const int RocketWidth = 10;
        public const int RocketHeight = 30;
        public const int ObstacleWidth = 700;
        public const int ObstacleHeight = 10;
        public int RocketX;
        public int RocketY;
        private readonly Population _population;
        private readonly Target _target;
        private readonly List<Obstacle> _obstacles;
        private int _width;
        private int _height;
        private DefaultRocketUpdater _rocketUpdater;
        private DefaultFitnessCalculator _fitnessCalculator;
        private int _count;

        public GameManager(int size, int windowWidth, int windowHeight)
        {
            _width = windowWidth;
            _height = windowHeight;
            RocketX = _width / 2 - RocketWidth / 2;
            RocketY = _height - RocketHeight-3;
            _target = new(windowWidth);
            _obstacles = new();
            InitialitzeObstacles();
            _population = new(size, RocketX, RocketY);
            _population.Redo += (sender, e) => Redo();
            _rocketUpdater = new(_population, _target.Loc, _obstacles.ExtractLocation(), _width, _height);
            _fitnessCalculator = new(_population, _target.Loc, _obstacles.ExtractLocation(), _width);
        }

        private void InitialitzeObstacles()
        {
            _obstacles.Add(new(_width- ObstacleWidth+100, 150, ObstacleWidth, ObstacleHeight));
        }

        public void Draw(Graphics graphics)
        {
            if (_population == null || _target == null || _obstacles == null)
                return;
            Update();
            foreach (Rocket current in _population)
            {
                current.Draw(graphics);
            }
            _target.Draw(graphics);
            foreach (Obstacle current in _obstacles)
                current.Draw(graphics);
            if (++_count == Lifespan)
            {
                Redo();
            }
        }

        private void Redo()
        {
            _fitnessCalculator.Calc();
            _population.NaturalSelection();
            _count = 0;
        }

        private void Update()
        {
            _rocketUpdater.Update(_count);
        }
    }
}
