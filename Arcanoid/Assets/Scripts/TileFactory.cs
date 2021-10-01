using Arcanoid.Data;
using Arcanoid.Models;
using Arcanoid.ViewModels;
using Arcanoid.Views;
using UnityEngine;

namespace Arcanoid
{
    public class TileFactory : Factory<BrickTile>
    {
        private readonly IHitModel _hitModel;
        private readonly IHitViewModel _hitViewModel;

        public TileFactory(IHitModel hitModel, IHitViewModel hitViewModel, GameSettings gameSettings) : base(gameSettings)
        {
            _hitModel = hitModel;
            _hitViewModel = hitViewModel;
        }


        public override BrickTile GetTileAt(Vector3 position, Vector3 scale)
        {
            var tile = Object.Instantiate(_gameSettings.TilePrefab, position, Quaternion.identity);
            var bricktile = tile.AddComponent<BrickTile>();
            bricktile.Construct(_hitViewModel);
            bricktile.SetScale(scale);
            bricktile.SetState(_hitModel.GetRandomState());
            return bricktile;
        }
    }

    public sealed class BoardFactory : Factory<BoardTile>
    {
        private readonly IInputViewModel _inputViewModel;
        private readonly IMovementViewModel _movementViewModel;
        private Ball _ball;

        public BoardFactory(GameSettings gameSettings, IInputViewModel inputViewModel, IMovementViewModel movementViewModel) : base(gameSettings)
        {
            _inputViewModel = inputViewModel;
            _movementViewModel = movementViewModel;
        }

        public override BoardTile GetTileAt(Vector3 position, Vector3 scale)
        {
            var tile = Object.Instantiate(_gameSettings.TilePrefab, position, Quaternion.identity);
            var bricktile = tile.AddComponent<BoardTile>();
            bricktile.Construct(_inputViewModel, _movementViewModel);
            bricktile.SetScale(scale);
            GetBall();
            _ball.Stick(tile);
            return bricktile;
        }

        private Ball GetBall()
        {
            if (_ball == null)
            {
                _ball = Object.Instantiate(_gameSettings.BallPrefab, Vector3.zero, Quaternion.identity).GetComponent<Ball>();
            }
            return _ball;
        }
    }
}
