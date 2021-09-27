using System;

namespace Arcanoid
{
    public interface IInputViewModel
    {
        public event Action OnLaunch;
        public float Axes { get; }

        public void Launch();
        public void SetAxis(float axis);
    }
}
