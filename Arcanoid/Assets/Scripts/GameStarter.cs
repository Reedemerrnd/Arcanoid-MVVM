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
        void Start()
        {
            var settings = Resources.Load<GameSettings>($"Settings/GameSettings");
            var screenBounds = new ScreenBounds(Camera.main);
            

            var board = FindObjectOfType<BoardTile>();
            board.SetScale(new Vector3(settings.BoardWidth, 0.3f,1f));
            var ball = FindObjectOfType<Ball>();
            var input = FindObjectOfType<PCInput>();

            var boardSpeedModel = new SpeedModel(settings.BoardSpeed);
            var ballSpeedModel = new SpeedModel(settings.BallSpeed);
            var hitModel = new HitModel(settings.States);
            var hitViewModel = new HitViewModel(hitModel);

            var tileFactory = new TileFactory(hitModel, hitViewModel, settings);

            var boardFiller = new BoardBuilder(screenBounds, settings, tileFactory);
            boardFiller.FillBoard();



            var boardSpeedViewModel = new MovementViewModel(boardSpeedModel);
            var ballSpeedViewModel = new MovementViewModel(ballSpeedModel);
            var inputVM = new InputViewModel();

            input.Construct(inputVM);
            ball.Construct(inputVM, ballSpeedViewModel);
            board.Construct(inputVM, boardSpeedViewModel);


        }

    }
}
