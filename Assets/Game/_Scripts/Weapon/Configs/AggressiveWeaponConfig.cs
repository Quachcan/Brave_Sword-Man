using System;
using Game._Scripts.Weapon.Structs;
using UnityEngine;

namespace Game.Scripts.Weapon.Configs
{
    [CreateAssetMenu(fileName = "NewAggressiveWeapon", menuName = "Config/Weapon Config/AggressiveWeapon")]
    public class AggressiveWeaponConfig : WeaponConfig
    {
        [SerializeField] private WeaponAttackDetails[] attackDetails;
        
        
        public WeaponAttackDetails[] AttackDetails
        {
            get => attackDetails; private set => attackDetails  = value;
        }

        private void OnEnable()
        {
            amountOfAttacks = attackDetails.Length;
            
            movementSpeed = new float[amountOfAttacks];

            for (int i = 0; i < amountOfAttacks; i++)
            {
                movementSpeed[i] = attackDetails[i].movementSpeed;
            }
        }
    }
}
