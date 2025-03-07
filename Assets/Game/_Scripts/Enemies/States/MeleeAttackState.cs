using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States;
using Game.Scripts.Cores.CoreComponents;
using Game.Scripts.Enemies.States.Data;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class MeleeAttackState : AttackState
    {
        protected MeleeAttackConfig StateConfig;

        private Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private Movement movement;
        
        protected CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
        private CollisionSenses collisionSenses;

        public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, MeleeAttackConfig stateConfig) : base(entity, stateMachine, animBoolName, attackPosition)
        {
            this.StateConfig = stateConfig;
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void FinishAttack()
        {
            base.FinishAttack();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

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
