using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newDodgeStateData", menuName = "Data/State Data/Dodge State")]
    public class DodgeStateConfig : ScriptableObject
    {
        public float dodgeSpeed = 10f;
        public float dodgeTime = 0.2f;
        public float dodgeCooldown = 2f;
        public Vector2 dodgeAngle;
    }
}
