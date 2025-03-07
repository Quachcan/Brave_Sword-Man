using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Cores.CoreComponents;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class ChargeState : State
    {
        protected ChargeStateConfig StateConfig;

        protected bool IsPlayerInMinAgroRange;
        protected bool IsDetectingLedge;
        protected bool IsDetectingWall;
        protected bool IsChargeTimeOver;
        protected bool PerformCloseRangeAction;

        protected Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private Movement movement;
        
        protected CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
        private CollisionSenses collisionSenses;
        
        public ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, ChargeStateConfig stateConfig) : base(entity, stateMachine, animBoolName)
        {
            this.StateConfig = stateConfig;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
            IsDetectingLedge = CollisionSenses.LedgeVertical;
            IsDetectingWall = CollisionSenses.WallFront;

            PerformCloseRangeAction = Entity.CheckPlayerInCloseRangeAction();
        }

        public override void Enter()
        {
            base.Enter();

            IsChargeTimeOver = false;
            Movement.SetVelocityX(StateConfig.chargeSpeed * Movement.FacingDirection);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Movement?.SetVelocityX(StateConfig.chargeSpeed * Movement.FacingDirection);

            if (Time.time >= StartTime + StateConfig.chargeTime)
            {
                IsChargeTimeOver = true;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
