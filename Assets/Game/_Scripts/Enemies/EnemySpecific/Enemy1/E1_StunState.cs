using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Enemies.States.Data;

namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_StunState : StunState
    {
        private _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy;

        public E1_StunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, StunStateConfig stateConfig, _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateConfig)
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

            if (IsStunTimeOver)
            {
                if (PerformCloseRangeAction)
                {
                    StateMachine.ChangeState(enemy.MeleeAttackState);
                }
                else if (IsPlayerInMinAgroRange)
                {
                    StateMachine.ChangeState(enemy.ChargeState);
                }
                else
                {
                    enemy.LookForPlayerState.SetTurnImmediately(true);
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
