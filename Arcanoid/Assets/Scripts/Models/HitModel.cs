using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid.Models
{
    public class HitModel : IHitModel
    {
        private Dictionary<int, TileState> _states;

        public HitModel(params Color[] tileStates)
        {
            _states = new Dictionary<int, TileState>(tileStates.Length);
            for (int i = 0; i < tileStates.Length; i++)
            {
                var state = new TileState(i, tileStates[i]);
                _states.Add(i, state);
            }
        }

        public TileState GetRandomState() => _states[Random.Range(1, _states.Count)];

        public TileState UpdateState(TileState state) => state.HitsToDestroy - 1 <= 0 ? _states[0] : _states[state.HitsToDestroy-1];
    }
}
