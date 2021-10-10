namespace Arcanoid.Models
{
    class SpeedModel : ISpeedModel
    {
        private float _speed;
        public float Speed => _speed;

        public SpeedModel(float speed = 0)
        {
            _speed = speed;
        }
    }
}
