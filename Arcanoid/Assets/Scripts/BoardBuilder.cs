using Arcanoid.Data;
using Arcanoid.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid
{
    class BoardBuilder
    {
        private readonly IScreenBounds _screenBounds;
        private readonly GameSettings _gameSettings;
        private readonly ITileFactory<BrickTile> _tileFactory;
        private readonly ITileFactory<BoardTile> _player;
        private List<Vector3> _cells;
        private Vector2 _cellSize;

        public BoardBuilder(IScreenBounds screenBounds, GameSettings gameSettings, ITileFactory<BrickTile> tileFactory, ITileFactory<BoardTile> player)
        {
            _screenBounds = screenBounds;
            _gameSettings = gameSettings;
            _tileFactory = tileFactory;
            _player = player;
        }


        public void FillBoard()
        {
            GetSpawnPoints();
            foreach (var point in _cells)
            {
                _tileFactory.GetTileAt(point, _cellSize);
            }
            SpawnPlayer();

        }

        private void SpawnPlayer()
        {
            var boarPosition = GetBoardSpawnPoint();
            var boardScale = new Vector3(_gameSettings.BoardWidth, 0.3f, 1f);
            _player.GetTileAt(boarPosition, boardScale);

        }

        private Vector3 GetBoardSpawnPoint()
        {
            var x = (Mathf.Abs(_screenBounds.TopRight.x) - Mathf.Abs(_screenBounds.BottomLeft.x))/2;
            var y = 1f; // magick number
            return new Vector3(x, y, 0f);
        }

        private void GetSpawnPoints()
        {
            var topRightYAbs = Mathf.Abs(_screenBounds.TopRight.y);
            var screenMiddleY = (topRightYAbs - Mathf.Abs(_screenBounds.BottomLeft.y)) / 2f;
            _cells = new List<Vector3>(_gameSettings.Collumns * _gameSettings.Rows);
            _cellSize = new Vector3((_screenBounds.TopRight.x - _screenBounds.BottomLeft.x) / _gameSettings.Collumns, (_screenBounds.TopRight.y - screenMiddleY) / _gameSettings.Rows, 1f);
            var cellCenter = new Vector3(_screenBounds.BottomLeft.x + (_cellSize.x / 2), screenMiddleY + (_cellSize.y / 2), 0f);
            for (int i = 0; i < _gameSettings.Rows; i++)
            {
                for (int j = 0; j < _gameSettings.Collumns; j++)
                {
                    _cells.Add(cellCenter);
                    cellCenter.x += _cellSize.x;
                }
                cellCenter.x = _screenBounds.BottomLeft.x + (_cellSize.x / 2);
                cellCenter.y += _cellSize.y;
            }
        }


    }
}
