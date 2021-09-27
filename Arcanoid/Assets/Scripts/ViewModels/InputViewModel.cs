using System;

namespace Arcanoid
{
    public class InputViewModel : IInputViewModel
    {
        private float _axes;

        public float Axes => _axes;
        public event Action OnLaunch = () => { };

        public void Launch()
        {
            OnLaunch();
        }

        public void SetAxis(float axis)
        {
            _axes = axis;
        }
        ~InputViewModel()
        {
            OnLaunch = null;
        }
    }
}
