using UnityEngine;

namespace Arcanoid.Inputs
{
    public class PCInput : MonoBehaviour
    {
        private IInputViewModel _inputViewModel;

        public void Construct(IInputViewModel input)
        {
            _inputViewModel = input;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _inputViewModel.Launch();
            }
        }
        private void FixedUpdate()
        {
            var axis = Input.GetAxis("Horizontal");
            _inputViewModel.SetAxis(axis);
        }
    }
}
