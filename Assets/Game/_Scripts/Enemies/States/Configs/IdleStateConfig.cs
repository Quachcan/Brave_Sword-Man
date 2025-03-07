using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/Idle State")]
    public class IdleStateConfig : ScriptableObject
    {
        public float minIdleTime = 1f;
        public float maxIdleTime = 2f;
    }
}
