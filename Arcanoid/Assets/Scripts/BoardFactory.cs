using Arcanoid.Data;
using Arcanoid.Views;
using UnityEngine;

namespace Arcanoid
{
    public sealed class BoardFactory : Factory<BoardTile>
    {
        private readonly IInputViewModel _inputViewModel;
        private readonly IMovementViewModel _movementViewModel;
        private readonly IMovementViewModel _ballMovement;
        private Ball _ball;

        public BoardFactory(GameSettings gameSettings, IInputViewModel inputViewModel, IMovementViewModel movementViewModel, IMovementViewModel ballMovement) : base(gameSettings)
        {
            _inputViewModel = inputViewModel;
            _movementViewModel = movementViewModel;
            _ballMovement = ballMovement;
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
            _ball.Construct(_inputViewModel, _ballMovement);
            return _ball;
        }
    }
}
