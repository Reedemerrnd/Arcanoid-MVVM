using System;

namespace Arcanoid.ViewModels
{
    public interface IGameOverViewModel
    {
        public event Action OnGameOver;
        public void GameOver();
    }
}
