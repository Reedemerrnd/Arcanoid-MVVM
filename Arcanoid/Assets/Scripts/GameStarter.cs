using Arcanoid.Inputs;
using Arcanoid.Models;
using Arcanoid.ViewModels;
using Arcanoid.Views;
using UnityEngine;

namespace Arcanoid
{
    public class GameStarter : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var board = FindObjectOfType<BoardTile>();
            var ball = FindObjectOfType<Ball>();
            var input = FindObjectOfType<PCInput>();

            var speedModel = new SpeedModel(100);
            //var hitModel = new HitModel(new TileState(0, Color.white), new TileState(1, Color.black));

            var movementVM = new MovementViewModel(speedModel);
            var inputVM = new InputViewModel();

            input.Construct(inputVM);
            ball.Construct(inputVM);
            board.Construct(inputVM, movementVM);


        }

    }
}
