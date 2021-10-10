using UnityEngine;

namespace Arcanoid.Views
{
    public sealed class BoardTile : BaseTile
    {
        private Rigidbody2D _rigidbody;
        private IInputViewModel _input;
        private IMovementViewModel _movement;


        public void Construct(IInputViewModel inputViewModel, IMovementViewModel movement)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _input = inputViewModel;
            _movement = movement;
            _rigidbody.isKinematic = false;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = Vector2.right * _input.Axes * _movement.Speed * Time.fixedDeltaTime;
        }
    }
}
