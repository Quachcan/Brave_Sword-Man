using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Enemies.States;
using Game.Scripts.Enemies.States.Data;

namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_ChargeState : ChargeState
    {
        private _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy;

        public E1_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, ChargeStateConfig stateConfig, _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateConfig)
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
                StateMachine.ChangeState(enemy.MeleeAttackState);
            }
            else if (!IsDetectingLedge || IsDetectingWall)
            {
                StateMachine.ChangeState(enemy.LookForPlayerState);
            }
            else if (IsChargeTimeOver)
            {
                if (IsPlayerInMinAgroRange)
                {
                    StateMachine.ChangeState(enemy.PlayerDetectedState);
                }
                else
                {
                    StateMachine.ChangeState(enemy.LookForPlayerState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
