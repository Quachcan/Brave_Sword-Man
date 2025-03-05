namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_MoveState : MoveState
    {
        private Enemy1 enemy;

        public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

            if (IsPlayerInMinAgroRange)
            {
                StateMachine.ChangeState(enemy.playerDetectedState);
            }
            else if(IsDetectingWall || !IsDetectingLedge)
            {
                enemy.idleState.SetFlipAfterIdle(true);
                StateMachine.ChangeState(enemy.idleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
