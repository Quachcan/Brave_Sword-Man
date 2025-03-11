using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States;
using Game.Scripts.Enemies.States.Data;

namespace Game._Scripts.Enemies.EnemySpecific.Enemy3
{
    public class E3MoveState : MoveState
    {
        private Enemy3 enemy;
        
        public E3MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, MoveStateConfig stateConfig, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateConfig)
        {
            this.enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();


            if (IsPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(enemy.PlayerDetectedState);
            }
            else if (IsDetectingWall || !IsDetectingLedge)
            {
                enemy.IdleState.SetFlipAfterIdle(true);
                StateMachine.ChangeState(enemy.IdleState);
            }
        }
    }
}
