using System;
using UnityEngine;
using Arcanoid.ViewModels;

namespace Arcanoid.Views
{
    public sealed class BrickTile : BaseTile
    {
        public event Action<TileState> OnHit = (s) => { };
        private TileState _state;
        private IHitViewModel _hitViewModel;

        public void Construct(IHitViewModel hitViewModel)
        {
            _hitViewModel = hitViewModel;
            OnHit += _hitViewModel.ProcessHit;
            _hitViewModel.OnDisable += Disable;
            _hitViewModel.OnStateChanged += SetState;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Ball>(out _))
            {
                OnHit(_state);
            }
        }

        private void SetState(TileState state)
        {
            _state = state;
            SetColor(state.Color);
        }


        private void Disable()
        {
            Enable(false);
        }

        private void OnDisable()
        {
            OnHit = (s) => { };
            _hitViewModel.OnDisable -= Disable;
            _hitViewModel.OnStateChanged -= SetState;
        }
    }
}
