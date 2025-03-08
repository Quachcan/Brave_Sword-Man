using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.EnemySpecific.Enemy3
{
    public class E3RangeAttackState : RangedAttackState
    {
        private Enemy3 enemy;
        private bool isPlayerInMaxAgroRanged;
        
        public E3RangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, RangedAttackStateConfig stateConfig, Enemy3 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateConfig)
        {
            this.enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsAnimationFinished)
            {
                if (IsPlayerInMinAgroRange)
                {
                    StateMachine.ChangeState(enemy.PlayerDetectedState);
                }
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsPlayerInMinAgroRange = Entity.CheckPlayerInMaxAgroRange();
        }
    }
}
