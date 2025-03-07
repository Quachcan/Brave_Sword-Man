using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Enemies.States.Data;

namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_LookForPlayerState : LookForPlayerState
    {
        private _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy;

        public E1_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, LookForPlayerConfig stateConfig, _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateConfig)
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

            if (IsPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(enemy.PlayerDetectedState);
            }
            else if (IsAllTurnsTimeDone)
            {
                StateMachine.ChangeState(enemy.MoveState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
