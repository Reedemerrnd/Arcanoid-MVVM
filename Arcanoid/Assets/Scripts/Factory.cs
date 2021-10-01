using Arcanoid.Data;
using Arcanoid.Views;
using UnityEngine;

namespace Arcanoid
{
    public abstract class Factory<T> : ITileFactory<T> where T : BaseTile
    {
        protected readonly GameSettings _gameSettings;

        public Factory(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public abstract T GetTileAt(Vector3 position, Vector3 scale);
    }
}
