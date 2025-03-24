using UnityEngine;

namespace Game._Scripts.Enemies.States.Configs
{
    [CreateAssetMenu(fileName = "newRangedAttackStateData", menuName = "Config/Enemy State Config/Ranged Attack State")]
    public class RangedAttackStateConfig : ScriptableObject
    {
        public GameObject projectilePrefab;
        public float projectileDamage = 10f;
        public float projectileSpeed = 12f;
        public float projectileTravelDistance;
        public float projectileLifeTime;
    }
}
