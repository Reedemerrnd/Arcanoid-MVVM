using UnityEngine;

namespace Arcanoid.Data
{
    [CreateAssetMenu(menuName = "Settings")]
    public class GameSettings : ScriptableObject
    {
        public float ScoreBonus;

        [Header("Ball")]
        public float BallSpeed;
        public float BallSize;

        [Header("PlayerBoard")]
        public float BoardSpeed;
        public float BoardWidth;

        [Header("Board Size")]
        public int Rows;
        public int Collumns;
        public float TileGap;

        [Header("Tile Settings")]
        public Color[] States;
        public GameObject TilePrefab;
        public GameObject BallPrefab;
    }
}
