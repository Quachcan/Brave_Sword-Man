using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newPlayerDetectedStateConfig", menuName = "Config/Enemy State Config/Player Detected State")]
    public class PlayerDetectedConfig : ScriptableObject
    {
        public float longRangeActionTime = 1.5f;
    }
}
