using static SmartRockets.Helpers.RandomProvider;
using static SmartRockets.Helpers.Vector2Helper;
using System.Numerics;

namespace SmartRockets.Game
{
    internal sealed class Dna
    {
        private Vector2[] _genes;
        private int _lifespan;

        public Dna(int lifespan)
        {
            _lifespan = lifespan;
            InitializeGenes();
        }

        public Dna(Vector2[] genes)
        {
            _genes = genes;
            _lifespan = _genes.Length;
        }

        public Vector2[] Genes => _genes;

        private void InitializeGenes()
        {
            _genes = new Vector2[_lifespan];

            for (int i = 0; i < _lifespan; i++)
            {
                if (Rand.NextDouble() < 0.3 && i > 0)
                    if(Rand.NextDouble() < 0.7)
                        _genes[i] = Vector2.Negate(_genes[i - 1]);
                    else
                    _genes[i] = _genes[i - 1];
                else
                    _genes[i] = Random2D();

                _genes[i] = _genes[i].SetMag(GameManager.MaxForce);
            }
        }

        public void Mutate()
        {
            Mutate(Rand.NextDouble() < 0.5);
        }
        private void Mutate(bool performSmartMutation)
        {
            if (performSmartMutation)
            {
                //TODO: Add 'smart'-mutation logic (generate mutate gene which simplyfies path to target)

                /*return;*/ //TODO: remove comment on "return;" when 'smart'-logic was added
            }

            for (int i = 0; i < _genes.Length; i++)
            {
                if (Rand.NextDouble() < 0.01)
                {
                    _genes[i] = Random2D();
                    _genes[i].SetMag(GameManager.MaxForce);
                }
            }
        }
    }
}
