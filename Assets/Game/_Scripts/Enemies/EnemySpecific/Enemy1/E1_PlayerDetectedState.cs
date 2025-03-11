using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States;
using Game.Scripts.Enemies.States;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_PlayerDetectedState : PlayerDetectedState
    {
        private _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy;
        
        public E1_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, PlayerDetectedConfig stateConfig, _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateConfig)
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

            if (PerformCloseRangeAction)
            {
                StateMachine.ChangeState(enemy.MeleeAttackState);
            }
            else if (PerformLongRangeAction)
            {            
                StateMachine.ChangeState(enemy.ChargeState);
            }
            else if (!IsPlayerInMaxAgroRange)
            {
                StateMachine.ChangeState(enemy.LookForPlayerState);
            }
            else if (!IsDetectingLedge)
            {
                Movement.Flip();
                StateMachine.ChangeState(enemy.MoveState);
            }
        
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
