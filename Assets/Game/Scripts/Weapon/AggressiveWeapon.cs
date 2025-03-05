using System.Collections.Generic;
using Game.Scripts.Interfaces;
using Game.Scripts.Weapon.Configs;
using System.Linq;
using UnityEngine;

namespace Game.Scripts.Weapon
{
    public class AggressiveWeapon : Weapon
    {
        protected AggressiveWeaponConfig AggressiveWeaponConfig;
        
        private readonly List<IDamageable> detectDamageable = new List<IDamageable>();

        protected override void Awake()
        {
            base.Awake();

            if (config.GetType() == typeof(AggressiveWeaponConfig))
            {
                AggressiveWeaponConfig = (AggressiveWeaponConfig)config;
            }
            else
            {
                Debug.LogError("wrong config type");
            }
        }

        public override void AnimationActionTrigger()
        {
            base.AnimationActionTrigger();
            
            CheckMeleeAttack();
        }

        private void CheckMeleeAttack()
        {
            WeaponAttackDetails details = AggressiveWeaponConfig.AttackDetails[AttackCounter];
            
            foreach (var item in detectDamageable.ToList())
            {
                item.Damage(details.damageAmount);
            }
        }

        public void AddToDetected(Collider2D other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable != null)
            {
                detectDamageable.Add(damageable);
            }
        }

        public void RemoveFromDetected(Collider2D other)
        {
            
            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable != null)
            {
                detectDamageable.Remove(damageable);
            }
        }
    }
}
