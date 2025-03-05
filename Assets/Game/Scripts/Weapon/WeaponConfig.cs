using UnityEngine;

namespace Game.Scripts.Weapon
{
    [CreateAssetMenu(fileName = "NewWeaponConfig", menuName = "Config/Weapon Config/Weapon")]
    public class WeaponConfig : ScriptableObject
    {
        public int amountOfAttacks {get; protected set;}
        public float[] movementSpeed {get; protected set;}
    }
}
