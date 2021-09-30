using Arcanoid.Models;
using Arcanoid.Views;
using UnityEngine;

namespace Arcanoid.ViewModels
{
    public class HitViewModel : IHitViewModel
    {
        private readonly IHitModel _hitModel;


        public HitViewModel(IHitModel hitModel)
        {
            _hitModel = hitModel;
        }

        public void ProcessHit(BrickTile tile)
        {
            var newState = _hitModel.UpdateState(tile.State);
            tile.SetState(newState);
            if (newState.HitsToDestroy == 0)
            {
                tile.Disable();
            }
        }
    }
}
