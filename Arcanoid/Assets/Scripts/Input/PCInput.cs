using UnityEngine;

namespace Arcanoid.Inputs
{
    public class PCInput : MonoBehaviour
    {
        private float _axis;
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
            _axis = Input.GetAxis("Horizontal");
            _inputViewModel.SetAxis(_axis);
        }
    }
}
