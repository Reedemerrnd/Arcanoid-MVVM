using Arcanoid.Models;

namespace Arcanoid.ViewModels
{
    public class MovementViewModel : IMovementViewModel
    {
        private ISpeedModel _speedModel;
        public float Speed => _speedModel.Speed;

        public MovementViewModel(ISpeedModel speedModel)
        {
            _speedModel = speedModel;
        }
    }
}
