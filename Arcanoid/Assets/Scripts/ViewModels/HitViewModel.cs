using Arcanoid.Models;
using System;

namespace Arcanoid.ViewModels
{
    public class HitViewModel : IHitViewModel
    {
        private readonly IHitModel _hitModel;

        public event Action<TileState> OnStateChanged = (s) => { };
        public event Action OnDisable = () => { };

        public HitViewModel(IHitModel hitModel)
        {
            _hitModel = hitModel;
        }

        public void ProcessHit(TileState state)
        {
            var newState = _hitModel.UpdateState(state);
            if (newState.HitsToDestroy == 0)
            {
                OnDisable();
            }
            else
            {
                OnStateChanged(newState);
            }
        }
        ~HitViewModel()
        {
            OnDisable = null;
            OnStateChanged = null;
        }
    }
}
