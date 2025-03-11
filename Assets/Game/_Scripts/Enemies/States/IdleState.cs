using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class IdleState : State
    {
        private Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private Movement movement;
        
        protected CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
        private CollisionSenses collisionSenses;
        
        protected IdleStateConfig StateConfig;

        protected bool FlipAfterIdle;
        protected bool IsIdleTimeOver;
        protected bool IsPlayerInMinAgroRange;

        protected float IdleTime;

        public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, IdleStateConfig stateConfig) : base(entity, stateMachine, animBoolName)
        {
            this.StateConfig = stateConfig;
        }

        public override void DoChecks()
        {
            base.DoChecks();
            IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
        }

        public override void Enter()
        {
            base.Enter();

            Movement.SetVelocityX(0f);
            IsIdleTimeOver = false;        
            SetRandomIdleTime();
        }

        public override void Exit()
        {
            base.Exit();

            if (FlipAfterIdle)
            {
                Movement.Flip();
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Movement.SetVelocityX(0f);

            if (Time.time >= StartTime + IdleTime)
            {
                IsIdleTimeOver = true;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();        
        }

        public void SetFlipAfterIdle(bool flip)
        {
            FlipAfterIdle = flip;
        }

        private void SetRandomIdleTime()
        {
            IdleTime = Random.Range(StateConfig.minIdleTime, StateConfig.maxIdleTime);
        }
    }
}
