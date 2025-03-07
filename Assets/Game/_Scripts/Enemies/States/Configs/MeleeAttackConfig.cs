using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]
    public class MeleeAttackConfig : ScriptableObject
    {
        public float attackRadius = 0.5f;
        public float attackDamage = 10f;

        public Vector2 knockBackAngle = Vector2.one;
        public float knockBackStrength = 10f;

        public LayerMask whatIsPlayer;
    }
}
