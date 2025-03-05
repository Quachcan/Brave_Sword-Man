namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_StunState : StunState
    {
        private Enemy1 enemy;

        public E1_StunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

            if (isStunTimeOver)
            {
                if (performCloseRangeAction)
                {
                    StateMachine.ChangeState(enemy.meleeAttackState);
                }
                else if (isPlayerInMinAgroRange)
                {
                    StateMachine.ChangeState(enemy.chargeState);
                }
                else
                {
                    enemy.lookForPlayerState.SetTurnImmediately(true);
                    StateMachine.ChangeState(enemy.lookForPlayerState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
