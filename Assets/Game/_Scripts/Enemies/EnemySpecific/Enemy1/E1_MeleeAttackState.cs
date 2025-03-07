using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Enemies.States;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_MeleeAttackState : MeleeAttackState
    {
        private Enemy1 enemy;

        public E1_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, MeleeAttackConfig stateConfig, Enemy1 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateConfig)
        {
            this.enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsAnimationFinished) return;
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
}
