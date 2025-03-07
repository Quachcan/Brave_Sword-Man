using System.Collections.Generic;
using Game.Scripts.Interfaces;
using Game.Scripts.Weapon.Configs;
using System.Linq;
using Game._Scripts.Cores.CoreComponents;
using Game.Scripts.Cores.CoreComponents;
using Game.Scripts.Weapon.Structs;
using UnityEngine;

namespace Game.Scripts.Weapon
{
    public class AggressiveWeapon : Weapon
    {
        protected AggressiveWeaponConfig AggressiveWeaponConfig;
        
        private Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        
        private Movement movement;
        
        private readonly List<IDamageable> detectedDamageables = new List<IDamageable>();
        private List<IKnockBackAble> detectedKnockBackAble = new List<IKnockBackAble>();

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
            
            foreach (var item in detectedDamageables.ToList())
            {
                item.Damage(details.damageAmount);
            }

            foreach (var item in detectedKnockBackAble.ToList())
            {
                item.KnockBack(details.knockBackAngle, details.knockBackStrength, Movement.FacingDirection);
            }
        }

        public void AddToDetected(Collider2D other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable is not null)
            {
                detectedDamageables.Add(damageable);
            }
            
            IKnockBackAble knockBackAble = other.GetComponent<IKnockBackAble>();
            if (knockBackAble is not null)
            {
                detectedKnockBackAble.Add(knockBackAble);
            }
        }

        public void RemoveFromDetected(Collider2D other)
        {
            
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable is not null)
            {
                detectedDamageables.Remove(damageable);
            }
            
            IKnockBackAble knockBackAble = other.GetComponent<IKnockBackAble>();
            if (knockBackAble is not null)
            {
                detectedKnockBackAble.Remove(knockBackAble);
            }
        }
    }
}
