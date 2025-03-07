using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]
    public class MoveStateConfig : ScriptableObject
    {
        public float movementSpeed = 3f;
    }
}
