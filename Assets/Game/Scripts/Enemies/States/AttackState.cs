using Game.Scripts.Enemies.State_Machine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class AttackState : State
    {
        protected Transform AttackPosition;

        protected bool IsAnimationFinished;
        protected bool IsPlayerInMinAgroRange;

        public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
        {
            this.AttackPosition = attackPosition;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
        }

        public override void Enter()
        {
            base.Enter();

            Entity.atsm.attackState = this;
            IsAnimationFinished = false;
            Core.Movement.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            //core.Movement.SetVelocityX(0f);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public virtual void TriggerAttack()
        {

        }

        public virtual void FinishAttack()
        {
            IsAnimationFinished = true;
        }
    }
}
