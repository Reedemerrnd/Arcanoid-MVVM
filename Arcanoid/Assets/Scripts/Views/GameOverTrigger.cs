using Arcanoid.ViewModels;
using UnityEngine;

namespace Arcanoid.Views
{
    public sealed class GameOverTrigger : BaseTile
    {
        private Collider2D _collider;
        private IGameOverViewModel _gameOverViewModel;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        public void Construct(IGameOverViewModel gameOverViewModel)
        {
            _gameOverViewModel = gameOverViewModel;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Ball>(out _))
            {
                _gameOverViewModel.GameOver();
            }
        }
    }
}
