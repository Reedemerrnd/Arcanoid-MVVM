using UnityEngine;

namespace Arcanoid.Views
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Ball : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private bool _isLaunched;
        private IMovementViewModel _movement;

        public void Construct(IInputViewModel input, IMovementViewModel movementViewModel)
        {
            input.OnLaunch += Launch;
            _movement = movementViewModel;
        }


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }


        private void Launch()
        {
            if (!_isLaunched)
            {
                var direction = new Vector3(Random.Range(-1f, 1f), 1f, 0f) * _movement.Speed;
                _rigidbody.AddForce(direction);
                _isLaunched = true;
            }
        }
    }
}
