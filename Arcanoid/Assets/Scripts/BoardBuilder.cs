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
        private List<BrickTile> _brickTiles;

        public List<BrickTile> Tiles => _brickTiles;

        public BoardBuilder(ScreenBounds screenBounds, GameSettings gameSettings, ITileFactory tileFactory)
        {
            _screenBounds = screenBounds;
            _gameSettings = gameSettings;
            _tileFactory = tileFactory;
        }


        public void FillBoard()
        {
            GetSpawnPoints();
            _brickTiles = new List<BrickTile>(_cells.Count);
            foreach (var point in _cells)
            {
                _brickTiles.Add(_tileFactory.GetTileAt(point, _cellSize));
            }
        }


        private void GetSpawnPoints()
        {
            var screenMiddleY = (Mathf.Abs(_screenBounds.TopRight.y) - Mathf.Abs(_screenBounds.BottomLeft.y)) / 2f;
            _cells = new List<Vector3>(_gameSettings.Collumns * _gameSettings.Rows);
            _cellSize = new Vector2((_screenBounds.TopRight.x - _screenBounds.BottomLeft.x) / _gameSettings.Collumns, (_screenBounds.TopRight.y - screenMiddleY) / _gameSettings.Rows);
            var cellPosition = new Vector2(_screenBounds.BottomLeft.x, screenMiddleY);
            while (cellPosition.y + _cellSize.y <= _screenBounds.TopRight.y)
            {
                cellPosition.x = _screenBounds.BottomLeft.x;
                while (cellPosition.x + _cellSize.x <= _screenBounds.TopRight.x)
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
