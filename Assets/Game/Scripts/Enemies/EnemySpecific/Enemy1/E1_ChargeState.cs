using Game.Scripts.Enemies.States;

namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_ChargeState : ChargeState
    {
        private Enemy1 enemy;

        public E1_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
        {
            this.enemy = enemy;
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

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (PerformCloseRangeAction)
            {
                StateMachine.ChangeState(enemy.meleeAttackState);
            }
            else if (!IsDetectingLedge || IsDetectingWall)
            {
                StateMachine.ChangeState(enemy.lookForPlayerState);
            }
            else if (IsChargeTimeOver)
            {
                if (IsPlayerInMinAgroRange)
                {
                    StateMachine.ChangeState(enemy.playerDetectedState);
                }
                else
                {
                    StateMachine.ChangeState(enemy.lookForPlayerState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
