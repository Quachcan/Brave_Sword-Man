using UnityEngine;

namespace Game._Scripts.Enemies.States.Configs
{
    [CreateAssetMenu(fileName = "newMeleeAttackStateConfig", menuName = "Config/Enemy State Config/Melee Attack State")]
    public class MeleeAttackConfig : ScriptableObject
    {
        public float attackRadius = 0.5f;
        public float attackDamage = 10f;
        public float attackCoolDown = 0.5f;

        public Vector2 knockBackAngle = Vector2.one;
        public float knockBackStrength = 10f;

        public LayerMask whatIsPlayer;
    }
}
