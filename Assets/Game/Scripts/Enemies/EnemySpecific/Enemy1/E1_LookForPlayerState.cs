﻿namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_LookForPlayerState : LookForPlayerState
    {
        private Enemy1 enemy;

        public E1_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
        {
            this.enemy = enemy;
        }

        public override void DoChecks()
        {
            base.DoChecks();
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
                StateMachine.ChangeState(enemy.playerDetectedState);
            }
            else if (IsAllTurnsTimeDone)
            {
                StateMachine.ChangeState(enemy.moveState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
