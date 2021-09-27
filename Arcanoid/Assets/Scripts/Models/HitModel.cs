using System.Collections.Generic;

namespace Arcanoid.Models
{
    public class HitModel : IHitModel
    {
        private Dictionary<int, TileState> _states;

        public HitModel(params TileState[] tileStates)
        {
            _states = new Dictionary<int, TileState>(tileStates.Length);
            foreach (var state in tileStates)
            {
                _states.Add(state.HitsToDestroy, state);
            }
        }

        public TileState UpdateState(TileState state) => state.HitsToDestroy - 1 <= 0 ? _states[0] : _states[state.HitsToDestroy - 1];
    }
}
