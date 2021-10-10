using UnityEngine;

namespace Arcanoid
{
    public interface IScreenBounds
    {
        public Vector3 TopRight { get; }
        public Vector3 BottomLeft { get; }
    }
}


