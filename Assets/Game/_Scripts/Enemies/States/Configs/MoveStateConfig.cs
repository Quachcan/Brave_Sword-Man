using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newMoveStateConfig", menuName = "Config/Enemy State Config/Move State")]
    public class MoveStateConfig : ScriptableObject
    {
        public float movementSpeed = 3f;
    }
}
