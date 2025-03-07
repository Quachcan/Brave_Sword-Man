using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newRangedAttackStateData", menuName = "Data/State Data/Ranged Attack State")]
    public class RangedAttackStateConfig : ScriptableObject
    {
        public GameObject projectile;
        public float projectileDamage = 10f;
        public float projectileSpeed = 12f;
        public float projectileTravelDistance;
    }
}
