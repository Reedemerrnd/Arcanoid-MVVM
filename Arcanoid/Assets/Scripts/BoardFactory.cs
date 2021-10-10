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
        private BoardTile _playerBoard;

        public BoardFactory(GameSettings gameSettings, IInputViewModel inputViewModel, IMovementViewModel movementViewModel, IMovementViewModel ballMovement) : base(gameSettings)
        {
            _inputViewModel = inputViewModel;
            _movementViewModel = movementViewModel;
            _ballMovement = ballMovement;
        }

        public override BoardTile GetTileAt(Vector3 position, Vector3 scale)
        {
            var tile = Object.Instantiate(_gameSettings.TilePrefab, position, Quaternion.identity);
            _playerBoard = tile.AddComponent<BoardTile>();
            _playerBoard.Construct(_inputViewModel, _movementViewModel);
            _playerBoard.SetScale(scale);
            GetBall();
            _ball.StickTo(tile);
            return _playerBoard;
        }

        public BoardTile GetBoard() => _playerBoard;

        public Ball GetBall()
        {
            if (_ball == null)
            {
                _ball = Object.Instantiate(_gameSettings.BallPrefab, Vector3.zero, Quaternion.identity).GetComponent<Ball>();
                _ball.Construct(_inputViewModel, _ballMovement);
            }
            return _ball;
        }
    }
}
