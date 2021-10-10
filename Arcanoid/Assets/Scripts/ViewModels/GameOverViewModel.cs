using System;
using Arcanoid.Views;

namespace Arcanoid.ViewModels
{
    class GameOverViewModel : IGameOverViewModel
    {
        private readonly Ball _ballView;
        private readonly BoardTile _playerBoardView;

        public event Action OnGameOver = ()=> { };

        public GameOverViewModel(Ball ballView, BoardTile playerBoardView)
        {
            _ballView = ballView;
            _playerBoardView = playerBoardView;
        }
        public void GameOver()
        {
            OnGameOver();
            _ballView.StickTo(_playerBoardView.gameObject);
        }


        ~GameOverViewModel()
        {
            OnGameOver = null;
        }
    }
}
