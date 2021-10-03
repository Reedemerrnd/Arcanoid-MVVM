using System;

namespace Arcanoid.ViewModels
{
    class GameOverViewModel : IGameOverViewModel
    {
        public event Action OnGameOver = ()=> { };

        public void GameOver() => OnGameOver();

        ~GameOverViewModel()
        {
            OnGameOver = null;
        }
    }
}
