using Arcanoid.Data;
using Arcanoid.Models;
using Arcanoid.ViewModels;
using Arcanoid.Views;
using UnityEngine;

namespace Arcanoid
{
    public class TileFactory : ITileFactory
    {
        private readonly IHitModel _hitModel;
        private readonly IHitViewModel _hitViewModel;
        private readonly GameSettings _gameSettings;

        public TileFactory(IHitModel hitModel,IHitViewModel hitViewModel , GameSettings gameSettings)
        {
            _hitModel = hitModel;
            _hitViewModel = hitViewModel;
            _gameSettings = gameSettings;
        }


        public BrickTile GetTileAt(Vector3 position, Vector3 scale)
        {
            var tile = Object.Instantiate(_gameSettings.TilePrefab, position, Quaternion.identity);
            //tile.transform.localScale = scale;
            var bricktile = tile.AddComponent<BrickTile>();
            bricktile.Construct(_hitViewModel);
            bricktile.SetScale(scale);
            bricktile.SetState(_hitModel.GetRandomState());
            return bricktile;
        }
    }
}
