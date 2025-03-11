using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newStunStateConfig", menuName = "Config/Enemy State Config/Stun State")]
    public class StunStateConfig : ScriptableObject
    {
        public float stunTime = 3f;

        public float stunKnockbackTime = 0.2f;
        public float stunKnockbackSpeed = 20f;
        public Vector2 stunKnockbackAngle;
    }
}
