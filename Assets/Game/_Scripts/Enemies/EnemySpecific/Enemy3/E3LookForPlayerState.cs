using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.EnemySpecific.Enemy3
{
    public class E3LookForPlayerState : LookForPlayerState
    {
        private Enemy3 enemy;
        public E3LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, LookForPlayerConfig stateConfig, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateConfig)
        {
            this.enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsPlayerInMaxAgroRange)
            {
                StateMachine.ChangeState(enemy.PlayerDetectedState);
            }
            else if (IsAllTurnsDone)
            {
                StateMachine.ChangeState(enemy.MoveState);
            }
        }
    }
}
