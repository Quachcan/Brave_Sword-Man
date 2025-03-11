using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States;
using Game._Scripts.Enemies.States.Configs;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.EnemySpecific.Enemy3
{
    public class E3RangeAttackState : RangeAttackState
    {
        private Enemy3 enemy;
        private bool isPlayerInMaxAgroRanged;


        public E3RangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, RangedAttackStateConfig stateConfig, Enemy3 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateConfig)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
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
                else
                {
                    StateMachine.ChangeState(enemy.LookForPlayerState);
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
