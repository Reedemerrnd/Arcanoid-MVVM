using UnityEngine;

namespace Arcanoid.Views
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Ball : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private bool _isLaunched;
        private IMovementViewModel _movement;
        private CircleCollider2D _collider;

        public void Construct(IInputViewModel input, IMovementViewModel movementViewModel)
        {
            input.OnLaunch += Launch;
            _movement = movementViewModel;
        }


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CircleCollider2D>();
        }


        public void StickTo(GameObject gameObject)
        {
            transform.SetParent(gameObject.transform);
            var position = CalculateStickPoint(gameObject);
            transform.position = position;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.isKinematic = true;
            _isLaunched = false;
        }

        private Vector3 CalculateStickPoint(GameObject gameObject)
        {
            var collider = gameObject.GetComponent<Collider2D>();
            var position = gameObject.transform.position;
            var border = collider.bounds.max.y;
            var selfBound = _collider.bounds.extents.y;
            position.y = border+selfBound;
            return position;
        }

        private void Launch()
        {
            if (!_isLaunched)
            {
                transform.SetParent(null);
                _rigidbody.isKinematic = false;
                var direction = new Vector3(Random.Range(-1f, 1f), 1f, 0f) * _movement.Speed;
                _rigidbody.AddForce(direction);
                _isLaunched = true;
            }
        }
    }
}
