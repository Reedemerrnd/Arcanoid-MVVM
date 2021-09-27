using UnityEngine;

namespace Arcanoid.Views
{
    public sealed class BoardTile : BaseTile
    {
        IInputViewModel _input;
        private IMovementViewModel _movement;

        public void Construct(IInputViewModel inputViewModel, IMovementViewModel movement)
        {
            _input = inputViewModel;
            _movement = movement;
        }

        private void Update()
        {
            transform.Translate(Vector3.right * _input.Axes * _movement.Speed * Time.deltaTime);
        }
    }
}
