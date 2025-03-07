using Game.Scripts.Cores;
using Game.Scripts.Player.PlayerStates.SubStates;
using UnityEngine;

namespace Game.Scripts.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponConfig config;
        
        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Counter = Animator.StringToHash("attackCounter");
        
        protected Animator BaseAnimator;
        protected Animator WeaponAnimator;

        protected PlayerAttackState state;

        protected Core Core;

        protected int AttackCounter;

        private bool isHit;
        
        protected virtual void Awake()
        {
            BaseAnimator = transform.Find("Base").GetComponent<Animator>();
            WeaponAnimator = transform.Find("Weapon").GetComponent<Animator>();
            
            gameObject.SetActive(false);
        }

        public virtual void EnterWeapon()
        {
            gameObject.SetActive(true);

            if (AttackCounter >= config.amountOfAttacks)
            {
                AttackCounter = 0;
            }
            
            BaseAnimator.SetBool(Attack, true);
            WeaponAnimator.SetBool(Attack, true);
            
            BaseAnimator.SetInteger(Counter, AttackCounter);
            WeaponAnimator.SetInteger(Counter, AttackCounter);
        }

        public virtual void ExitWeapon()
        {
            BaseAnimator.SetBool(Attack, false);
            WeaponAnimator.SetBool(Attack, false);

            if (isHit)
            {
                AttackCounter++;
            }
            else
            {
                AttackCounter = 0;
            }
            isHit = false;
            gameObject.SetActive(false);
        }

        public virtual void AnimationFinishTrigger()
        {
            state.AnimationFinishTrigger();
        }

        public virtual void AnimationStartMovementTrigger()
        {
            state.SetPlayerVelocity(config.movementSpeed[AttackCounter]);
        }

        public virtual void AnimationFinishMovementTrigger()
        {
            state.SetPlayerVelocity(0f);
        }

        public virtual void AnimationActionTrigger()
        {
            
        }

        public void InitializeWeapon(PlayerAttackState state, Core core)
        {
            this.state = state;
            this.Core = core;
        }
    }
}
