using Arcanoid.Data;
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
            var settings = Resources.Load<GameSettings>($"Settings/GameSettings");
            var screenBounds = new ScreenBounds(Camera.main);

            var board = FindObjectOfType<BoardTile>();
            board.SetScale(0.1f, settings.BoardWidth);
            var ball = FindObjectOfType<Ball>();
            var input = FindObjectOfType<PCInput>();

            var boardSpeedModel = new SpeedModel(settings.BoardSpeed);
            var ballSpeedModel = new SpeedModel(settings.BallSpeed);
            //var hitModel = new HitModel(new TileState(0, Color.white), new TileState(1, Color.black));

            var boardSpeedViewModel = new MovementViewModel(boardSpeedModel);
            var ballSpeedViewModel = new MovementViewModel(ballSpeedModel);
            var inputVM = new InputViewModel();

            input.Construct(inputVM);
            ball.Construct(inputVM, ballSpeedViewModel);
            board.Construct(inputVM, boardSpeedViewModel);


        }

    }
}
