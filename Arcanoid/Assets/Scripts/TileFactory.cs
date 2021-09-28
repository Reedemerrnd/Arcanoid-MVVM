using Arcanoid.Data;
using Arcanoid.Models;
using Arcanoid.Views;
using UnityEngine;

namespace Arcanoid
{
    public class TileFactory : ITileFactory
    {
        private readonly IHitModel _hitModel;
        private readonly GameSettings _gameSettings;

        public TileFactory(IHitModel hitModel, GameSettings gameSettings)
        {
            _hitModel = hitModel;
            _gameSettings = gameSettings;
        }


        public BrickTile GetTileAt(Vector3 position, Vector3 scale)
        {
            var tile = Object.Instantiate(_gameSettings.TilePrefab, position, Quaternion.identity);
            tile.transform.localScale = scale;
            var bricktile = tile.AddComponent<BrickTile>();
            bricktile.SetState(_hitModel.GetRandomState());
            return bricktile;
        }
    }
}
