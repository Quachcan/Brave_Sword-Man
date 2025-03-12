using UnityEngine;

namespace Game._Scripts.Weapon.Structs
{
    [System.Serializable]
    public struct WeaponAttackDetails
    {
        public string attackName;
        public float movementSpeed;
        public float damageAmount;
    
        public float knockBackStrength;
        public Vector2 knockBackAngle;
    }
}
