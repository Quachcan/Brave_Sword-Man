using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States;
using Game._Scripts.Enemies.States.Configs;
using Game.Scripts.Enemies.States;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1MeleeAttackState : MeleeAttackState
    {
        private Enemy1 enemy;

        private MeleeAttackConfig stateConfig;
        

        public E1MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, MeleeAttackConfig stateConfig, Enemy1 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateConfig)
        {
            this.enemy = enemy;
            this.stateConfig = stateConfig;
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
        
    }
}
