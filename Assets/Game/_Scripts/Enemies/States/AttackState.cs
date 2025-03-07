using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Cores.CoreComponents;
using UnityEngine;

namespace Game._Scripts.Enemies.States
{
    public class AttackState : State
    {
        protected Transform AttackPosition;

        protected bool IsAnimationFinished;
        protected bool IsPlayerInMinAgroRange;

        private Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private Movement movement;

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

            Entity.Atsm.attackState = this;
            IsAnimationFinished = false;
            Movement.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Movement.SetVelocityX(0f);
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
