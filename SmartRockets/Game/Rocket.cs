using static SmartRockets.Helpers.Vector2Helper;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;

namespace SmartRockets.Game
{
    internal sealed class Rocket : IDrawable
    {
        private int _width;
        private int _height;
        private Vector2 _pos;
        private Vector2 _vel;
        private Vector2 _acc;
        private Dna _dna;
        private double _fitness;
        private bool _completed;
        private bool _crashed;
        private bool _isWinner;

        public Rocket(int x, int y, int width, int height, Dna dna)
        {
            _width = width;
            _height = height;
            _pos = new(x, y);
            _vel = Vector2.Zero;
            _acc = Vector2.Zero;
            _dna = dna;
            _fitness = 0;
            _completed = false;
            _crashed = false;
            _isWinner = false;
        }

        public bool IsWinner
        {
            get => _isWinner;
            set => _isWinner = value;
        }

        public void SetPos(Vector2 pos) => _pos = pos;
        public Vector2 Position => _pos;

        public void NormalizeFitness(double maxFitness)
        {
            _fitness /= maxFitness;
        }

        public Dna Dna => _dna;
        public int Width => _width;
        public int Height => _height;
        public void ApplyForce(Vector2 force)
        {
            _acc = Vector2.Add(_acc, force);
        }

        public Vector2 Vel
        {
            get => _vel;
            set
            {
                if (value.GetMag() <= 4.0)
                    _vel = value;
            }
        }

        public Vector2 Acc
        {
            get => _acc;
            set => _acc = value;
        }
        private void InvokeDone(DoneReason reason) => Done?.Invoke(this,reason);
        public void SetFitness(double fitness) => _fitness = fitness;
        public double Fitness => _fitness;
        public void SetComplted(DoneReason reason) { _completed = true; InvokeDone(reason); }
        public bool HasCompleted() => _completed;
        public void SetCrashed(DoneReason reason) { _crashed = true; InvokeDone(reason); }
        public bool HasCrashed() => _crashed;
        public void Draw(Graphics graphics)
        {
            DrawRotatedRectangle(graphics, new Rectangle((int)_pos.X, (int)_pos.Y, _width, _height), _vel.GetHeading(false));
        }

        private void DrawRotatedRectangle(Graphics graphics, Rectangle rectangle, double angle)
        {
            using Matrix m = new();
            m.RotateAt((float)angle, new PointF(rectangle.Left + (rectangle.Width / 2),
                                      rectangle.Top + (rectangle.Height / 2)));
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Transform = m;
            if (!_completed && !_crashed)
                graphics.FillRectangle(Brushes.Purple, rectangle);
            graphics.DrawRectangle(_completed?Pens.Green: Pens.Purple, rectangle);
            graphics.ResetTransform();
        }

        public event DoneHandler Done;

        public delegate void DoneHandler(Rocket sender,DoneReason reason, object cause = null);

        public enum DoneReason
        {
            Goal,
            Border,
            Obstacle
        }
    }
}
