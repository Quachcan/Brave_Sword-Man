using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newIdleStateConfig", menuName = "Config/Enemy State Config/Idle State")]
    public class IdleStateConfig : ScriptableObject
    {
        public float minIdleTime = 1f;
        public float maxIdleTime = 2f;
    }
}
