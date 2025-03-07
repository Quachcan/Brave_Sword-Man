using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States;
using Game.Scripts.Enemies.States;
using Game.Scripts.Enemies.States.Data;

namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_MoveState : MoveState
    {
        private _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy;

        public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, MoveStateConfig stateConfig, _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateConfig)
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

            if (IsPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(enemy.PlayerDetectedState);
            }
            else if(IsDetectingWall || !IsDetectingLedge)
            {
                enemy.IdleState.SetFlipAfterIdle(true);
                StateMachine.ChangeState(enemy.IdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
