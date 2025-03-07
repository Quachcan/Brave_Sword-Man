using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newPlayerDetectedStateData", menuName = "Data/State Data/Player Detected State")]
    public class PlayerDetectedConfig : ScriptableObject
    {
        public float longRangeActionTime = 1.5f;
    }
}
