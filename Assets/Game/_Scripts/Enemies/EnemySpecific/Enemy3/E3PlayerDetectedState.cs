using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.EnemySpecific.Enemy3
{
    public class E3PlayerDetectedState : PlayerDetectedState
    {
        private Enemy3 enemy;
        
        private bool isPlayerInMaxAgroRange;
        
        public E3PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, PlayerDetectedConfig stateConfig, Enemy3 enemy) : base(entity, stateMachine, animBoolName, stateConfig)
        {
            this.enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (PerformLongRangeAction)
            {
                StateMachine.ChangeState(enemy.RangeAttackState);
            }
            else if (!isPlayerInMaxAgroRange)
            {
                StateMachine.ChangeState(enemy.LookForPlayerState);
            }
            
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isPlayerInMaxAgroRange = enemy.CheckPlayerInMaxAgroRange();
        }
    }
}
