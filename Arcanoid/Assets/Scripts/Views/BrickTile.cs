using System;
using UnityEngine;
using Arcanoid.ViewModels;

namespace Arcanoid.Views
{
    public sealed class BrickTile : BaseTile
    {
        public event Action<BrickTile> OnHit = (s) => { };
        private TileState _state;
        private IHitViewModel _hitViewModel;

        public TileState State => _state;

        public void Construct(IHitViewModel hitViewModel)
        {
            _hitViewModel = hitViewModel;
            OnHit += _hitViewModel.ProcessHit;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Hit");
            if (collision.transform.TryGetComponent<Ball>(out _))
            {
                OnHit(this);
            }
        }

        public void SetState(TileState state)
        {
            _state = state;
            SetColor(state.Color);
        }


        public void Disable()
        {
            Enable(false);
        }

        private void OnDisable()
        {
            OnHit = (s) => { };
        }
    }
}
