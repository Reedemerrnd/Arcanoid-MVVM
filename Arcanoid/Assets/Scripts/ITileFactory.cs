using Arcanoid.Views;
using UnityEngine;

namespace Arcanoid
{
    public interface ITileFactory<T> where T : BaseTile
    {
        public T GetTileAt(Vector3 position, Vector3 scale);
    }
}
