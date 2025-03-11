using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.States
{
    public class PlayerDetectedState : State
    {
        protected PlayerDetectedConfig StateConfig;

        protected Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private Movement movement;

        private CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
        private CollisionSenses collisionSenses;

        protected bool IsPlayerInMinAgroRange;
        protected bool IsPlayerInMaxAgroRange;
        protected bool PerformLongRangeAction;
        protected bool PerformCloseRangeAction;
        protected bool IsDetectingLedge;

        public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, PlayerDetectedConfig stateConfig) : base(entity, stateMachine, animBoolName)
        {
            this.StateConfig = stateConfig;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
            IsPlayerInMaxAgroRange = Entity.CheckPlayerInMaxAgroRange();
            IsDetectingLedge = CollisionSenses.LedgeVertical;
            PerformCloseRangeAction = Entity.CheckPlayerInCloseRangeAction();
        }

        public override void Enter()
        {
            base.Enter();

            PerformLongRangeAction = false;
            Movement?.SetVelocityX(0f);     
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Movement?.SetVelocityX(0f);

            if (Time.time >= StartTime + StateConfig.longRangeActionTime)
            {
                PerformLongRangeAction = true;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();        
        }
    }
}
