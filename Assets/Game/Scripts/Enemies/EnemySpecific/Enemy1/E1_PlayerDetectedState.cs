using Game.Scripts.Enemies.States;

namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1PlayerDetectedState : PlayerDetectedState
    {
        private Enemy1 enemy;
        
        public E1PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, bool isDetectingLedge) : base(entity, stateMachine, animBoolName, stateData, isDetectingLedge)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (PerformCloseRangeAction)
            {
                StateMachine.ChangeState(enemy.meleeAttackState);
            }
            else if (PerformLongRangeAction)
            {            
                StateMachine.ChangeState(enemy.chargeState);
            }
            else if (!IsPlayerInMaxAgroRange)
            {
                StateMachine.ChangeState(enemy.lookForPlayerState);
            }
            else if (!IsDetectingLedge)
            {
                Core.Movement.Flip();
                StateMachine.ChangeState(enemy.moveState);
            }
        
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
