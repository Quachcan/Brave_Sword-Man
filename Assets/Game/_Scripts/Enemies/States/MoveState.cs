using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Cores.CoreComponents;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.States
{
    public class MoveState : State
    {
        protected MoveStateConfig StateConfig;
        
        protected Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private Movement movement;
        
        protected CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
        private CollisionSenses collisionSenses;

        protected bool IsDetectingWall;
        protected bool IsDetectingLedge;
        protected bool IsPlayerInMinAgroRange;

        public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, MoveStateConfig stateConfig) : base(entity, stateMachine, animBoolName)
        {
            this.StateConfig = stateConfig;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsDetectingLedge = CollisionSenses.LedgeVertical;
            IsDetectingWall = CollisionSenses.WallFront;
            IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
        }

        public override void Enter()
        {
            base.Enter();

            if (Movement != null)
            {
                Movement.SetVelocityX(StateConfig.movementSpeed * Movement.FacingDirection);
            }
            else 
            {
                Debug.Log("Movement is null");
            }
        
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Movement?.SetVelocityX(StateConfig.movementSpeed * Movement.FacingDirection);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
