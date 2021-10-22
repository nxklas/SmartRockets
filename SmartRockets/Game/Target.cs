using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SmartRockets.Game
{
    internal sealed class Target : IDrawable
    {
        public const int Width = 15;
        public const int Height = 15;
        private Vector2 _loc;

        public Target(int windowWidth)
        {
            _loc = new(windowWidth / 2 - Width / 2, 25);
        }

        public Vector2 Loc => _loc;

        public void Draw(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Green, _loc.X, _loc.Y, Width, Height);
        }
    }
}
