using UnityEngine;

namespace Arcanoid
{
    public class ScreenBounds : IScreenBounds
    {
        private readonly Vector3 _bottomLeft;
        private readonly Vector3 _topRight;

        public Vector3 TopRight => _topRight;
        public Vector3 BottomLeft => _bottomLeft;


        public ScreenBounds(Camera camera)
        {
            _topRight = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, camera.depth));
            _bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.depth));
        }
    }
}


