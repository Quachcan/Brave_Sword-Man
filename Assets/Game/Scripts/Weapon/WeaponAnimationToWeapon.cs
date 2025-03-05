using System;
using UnityEngine;

namespace Game.Scripts
{
    public class WeaponAnimationToWeapon : MonoBehaviour
    {
        private Weapon.Weapon weapon;

        private void Start()
        {
            weapon = GetComponentInParent<Weapon.Weapon>();
        }

        private void AnimationFinishTrigger()
        {
            weapon.AnimationFinishTrigger();
        }

        private void AnimationStartMovementTrigger()
        {
            weapon.AnimationStartMovementTrigger();
        }

        private void AnimationFinishMovementTrigger()
        {
            weapon.AnimationFinishMovementTrigger();
        }

        private void AnimationActionTrigger()
        {
            weapon.AnimationActionTrigger();
        }
    }
}
