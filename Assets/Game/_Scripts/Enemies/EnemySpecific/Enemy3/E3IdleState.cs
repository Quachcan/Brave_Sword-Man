using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Enemies.States;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.EnemySpecific.Enemy3
{
    public class E3IdleState : IdleState
    {
        private Enemy3 enemy;
        public E3IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, IdleStateConfig stateConfig, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateConfig)
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
            else if (IsIdleTimeOver)
            {
                StateMachine.ChangeState(enemy.MoveState);
            }
        }
    }
}
