﻿using UnityEngine;

namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_MeleeAttackState : MeleeAttackState
    {
        private Enemy1 enemy;

        public E1_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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

        public override void FinishAttack()
        {
            base.FinishAttack();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsAnimationFinished)
            {
                if (IsPlayerInMinAgroRange)
                {
                    StateMachine.ChangeState(enemy.playerDetectedState);
                }
                else
                {
                    StateMachine.ChangeState(enemy.lookForPlayerState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void TriggerAttack()
        {
            base.TriggerAttack();
        }
    }
}
