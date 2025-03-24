using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newEntityConfig", menuName = "Config/Entity Config/Base Config")]
    public class EntityConfig : ScriptableObject
    {
        public float damageHopSpeed = 3f;

        public float minAgroDistance = 3f;
        public float maxAgroDistance = 4f;

        public float stunResistance = 3f;
        public float stunRecoveryTime = 2f;

        public float closeRangeActionDistance = 1f;

        public LayerMask whatIsPlayer;
    }
}
