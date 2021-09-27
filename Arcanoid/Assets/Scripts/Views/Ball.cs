using UnityEngine;

namespace Arcanoid.Views
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Ball : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private bool _isLanched;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Launch(float speed)
        {
            if (!_isLanched)
            {
                var direction = new Vector3(Random.Range(-1f,1f), 1f, 0f) * speed;
                _rigidbody.AddForce(direction);
            }
        }
    }
}
