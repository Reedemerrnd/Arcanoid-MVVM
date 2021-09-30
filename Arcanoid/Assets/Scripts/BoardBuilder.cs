using Arcanoid.Data;
using Arcanoid.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid
{
    class BoardBuilder
    {
        private readonly ScreenBounds _screenBounds;
        private readonly GameSettings _gameSettings;
        private readonly ITileFactory _tileFactory;

        private List<Vector3> _cells;
        private Vector2 _cellSize;

        public BoardBuilder(ScreenBounds screenBounds, GameSettings gameSettings, ITileFactory tileFactory)
        {
            _screenBounds = screenBounds;
            _gameSettings = gameSettings;
            _tileFactory = tileFactory;
        }


        public void FillBoard()
        {
            GetSpawnPoints();
            foreach (var point in _cells)
            {
                _tileFactory.GetTileAt(point, _cellSize);
            }
        }


        private void GetSpawnPoints()
        {
            var topRightYAbs = Mathf.Abs(_screenBounds.TopRight.y);
            var screenMiddleY = (topRightYAbs - Mathf.Abs(_screenBounds.BottomLeft.y)) / 2f;
            _cells = new List<Vector3>(_gameSettings.Collumns * _gameSettings.Rows);
            _cellSize = new Vector3((_screenBounds.TopRight.x - _screenBounds.BottomLeft.x) / _gameSettings.Collumns, (topRightYAbs - screenMiddleY) / _gameSettings.Rows, 1f);
            var cellPosition = new Vector2(_screenBounds.BottomLeft.x, screenMiddleY);
            while (cellPosition.y + _cellSize.y <= _screenBounds.TopRight.y + 0.1f)
            {
                cellPosition.x = _screenBounds.BottomLeft.x;
                while (cellPosition.x + _cellSize.x <= _screenBounds.TopRight.x + 0.1f)
                {
                    var center = new Vector2(cellPosition.x + (_cellSize.x / 2), cellPosition.y + (_cellSize.y / 2));
                    _cells.Add(center);
                    cellPosition.x += _cellSize.x;
                }
                cellPosition.y += _cellSize.y;
            }
        }


    }
}
