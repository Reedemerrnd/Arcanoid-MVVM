using System;

namespace Arcanoid.ViewModels
{
    public interface IHitViewModel
    {
        public event Action<TileState> OnStateChanged;
        public event Action OnDisable;

        public void ProcessHit(TileState state);
    }
}
