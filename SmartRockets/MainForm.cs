using SmartRockets.Game;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartRockets
{
    internal sealed partial class MainForm : Form
    {
        private GameManager _game;

        public MainForm()
        {
            InitializeComponent();
            SetFps(60);
            _game = new(2500, ClientRectangle.Width, ClientRectangle.Height);
            _idleLoop.Start();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            _game.Draw(e.Graphics);
        }

        private void _idleLoop_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void SetFps(int fps)
        {
            _idleLoop.Interval = 1000 / fps;
        }
    }
}
