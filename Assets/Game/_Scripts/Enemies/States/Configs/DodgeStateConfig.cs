using UnityEngine;

namespace Game._Scripts.Enemies.States.Configs
{
    [CreateAssetMenu(fileName = "newDodgeStateConfig", menuName = "Config/Enemy State Config/Dodge State")]
    public class DodgeStateConfig : ScriptableObject
    {
        public float dodgeSpeed = 10f;
        public float dodgeTime = 0.2f;
        public float dodgeCooldown = 2f;
        public Vector2 dodgeAngle;
    }
}
