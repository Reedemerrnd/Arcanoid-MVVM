using UnityEngine;

namespace Arcanoid.Data
{
    [CreateAssetMenu(menuName = "Settings")]
    class GameSettings : ScriptableObject
    {
        public float BallSpeed;
        public float BoardSpeed;
        public float BoardWidth;
        public float ScoreBonus;
    }
}
