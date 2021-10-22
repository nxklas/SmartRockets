using SmartRockets.Game.Abstracts;
using SmartRockets.Game.Generators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace SmartRockets.Game
{
    internal sealed class Population : IEnumerable<Rocket>
    {
        private Rocket[] _rockets;
        private int _size;
        private int _rocketX;
        private int _rocketY;
        private RandomizedRocketGenerator _rocketGenerator;
        private int _finishedRockets;

        public Population(int size, int x, int y)
        {
            _size = size;
            _rocketX = x;
            _rocketY = y;
            _rocketGenerator = new(_size, GameManager.Lifespan, _rocketX, _rocketY);
            _finishedRockets = 0;
            InitializeRockes();
        }

        public Rocket this[int index]
        {
            get
            {
                return _rockets[index];
            }
        }

        public IEnumerator<Rocket> GetEnumerator()
        {
            return ((IEnumerable<Rocket>)_rockets).GetEnumerator();
        }

        public void NaturalSelection()
        {
            _rockets = new GeneticRocketGenerator(_rockets.Length, GameManager.Lifespan, _rocketX, _rocketY, _rockets, new DefaultEvaluator()).Generate();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _rockets.GetEnumerator();
        }

        private void InitializeRockes()
        {
            _rockets = _rocketGenerator.Generate();
            foreach (Rocket current in _rockets)
                current.Done +=(sender,reason,cause) =>RocketDone(sender);
        }

        private void RocketDone(Rocket sender)
        {
            sender.IsWinner = true;
            _finishedRockets++;
            if (_finishedRockets == _rockets.Length)
            {
                _finishedRockets = 0;
                Redo?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler Redo;
    }
}
