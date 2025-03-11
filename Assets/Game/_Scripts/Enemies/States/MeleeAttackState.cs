using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States.Configs;
using Game._Scripts.Interfaces;
using UnityEngine;

namespace Game._Scripts.Enemies.States
{
    public class MeleeAttackState : AttackState
    {
        protected MeleeAttackConfig StateConfig;
        
        public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, MeleeAttackConfig stateConfig) : base(entity, stateMachine, animBoolName, attackPosition)
        {
            this.StateConfig = stateConfig;
        }

        private Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private Movement movement;
        
        protected CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
        private CollisionSenses collisionSenses;

        public override void TriggerAttack()
        {
            base.TriggerAttack();

            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(AttackPosition.position, StateConfig.attackRadius, StateConfig.whatIsPlayer);

            foreach (Collider2D collider in detectedObjects)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();

                damageable?.Damage(StateConfig.attackDamage);

                IKnockBackAble knockbackable = collider.GetComponent<IKnockBackAble>();
                
                if(knockbackable != null)
                {
                    knockbackable.KnockBack(StateConfig.knockBackAngle, StateConfig.knockBackStrength, Movement.FacingDirection);
                }
            }
        }
    }
}
