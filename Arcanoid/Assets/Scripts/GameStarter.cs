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
            
            var input = FindObjectOfType<PCInput>();

            var boardSpeedModel = new SpeedModel(settings.BoardSpeed);
            var ballSpeedModel = new SpeedModel(settings.BallSpeed);
            var hitModel = new HitModel(settings.States);
            var hitViewModel = new HitViewModel(hitModel);

            var boardSpeedViewModel = new MovementViewModel(boardSpeedModel);
            var ballSpeedViewModel = new MovementViewModel(ballSpeedModel);
            var inputVM = new InputViewModel();

            var tileFactory = new TileFactory(hitModel, hitViewModel, settings);
            var playerFactory = new BoardFactory(settings, inputVM, boardSpeedViewModel, ballSpeedViewModel);


            var boardFiller = new BoardBuilder(screenBounds, settings, tileFactory, playerFactory);
            boardFiller.FillBoard();

            input.Construct(inputVM);
        }

    }
}
