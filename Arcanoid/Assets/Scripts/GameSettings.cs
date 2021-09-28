using UnityEngine;

namespace Arcanoid.Data
{
    [CreateAssetMenu(menuName = "Settings")]
    public class GameSettings : ScriptableObject
    {
        public float BallSpeed;
        public float BoardSpeed;
        public float BoardWidth;
        public float ScoreBonus;
        [Header("Board Size")]
        public int Rows;
        public int Collumns;
        public float TileGap;
        [Header("Tile Settings")]
        public Color[] States;
        public GameObject TilePrefab;
    }
}
