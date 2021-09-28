using Arcanoid.Views;
using UnityEngine;

namespace Arcanoid
{
    public interface ITileFactory
    {
        public BrickTile GetTileAt(Vector3 position, Vector3 scale);
    }
}
