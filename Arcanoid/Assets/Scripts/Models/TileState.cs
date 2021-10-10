using UnityEngine;

namespace Arcanoid
{
    public struct TileState
    {
        private int _hitsToDestroy;
        private Color _color;

        public int HitsToDestroy => _hitsToDestroy;
        public Color Color => _color;

        public TileState(int hitsToDestroy, Color color)
        {
            _hitsToDestroy = hitsToDestroy;
            _color = color;
        }
    }
}
