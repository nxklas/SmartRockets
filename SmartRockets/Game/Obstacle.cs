using System.Drawing;
using System.Numerics;

namespace SmartRockets.Game
{
    internal sealed class Obstacle : IDrawable
    {
        private Vector2 _loc;
        private int _width;
        private int _height;

        public Obstacle(int x, int y, int width, int height)
        {
            _loc = new(x, y);
            _width = width;
            _height = height;
        }

        public Vector2 Loc => _loc;

        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.Red, _loc.X, _loc.Y, _width, _height);
        }
    }
}
