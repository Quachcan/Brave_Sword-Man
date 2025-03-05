using Game.Scripts.Enemies.State_Machine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class PlayerDetectedState : State
    {
        protected D_PlayerDetected stateData;

        protected bool IsPlayerInMinAgroRange;
        protected bool IsPlayerInMaxAgroRange;
        protected bool PerformLongRangeAction;
        protected bool PerformCloseRangeAction;
        protected bool IsDetectingLedge;

        public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, bool isDetectingLedge) : base(entity, stateMachine, animBoolName)
        {
            this.stateData = stateData;
            this.IsDetectingLedge = isDetectingLedge;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
            IsPlayerInMaxAgroRange = Entity.CheckPlayerInMaxAgroRange();
            IsDetectingLedge = Core.CollisionSenses.LedgeVertical;
            PerformCloseRangeAction = Entity.CheckPlayerInCloseRangeAction();
        }

        public override void Enter()
        {
            base.Enter();

            PerformLongRangeAction = false;
            Core.Movement.SetVelocityX(0f);     
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Core.Movement.SetVelocityX(0f);

            if (Time.time >= StartTime + stateData.longRangeActionTime)
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
