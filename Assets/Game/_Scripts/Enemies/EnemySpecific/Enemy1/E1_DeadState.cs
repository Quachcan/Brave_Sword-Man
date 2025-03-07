using Game._Scripts.Enemies.State_Machine;

namespace Game.Scripts.Enemies.EnemySpecific.Enemy1
{
    public class E1_DeadState : DeadState
    {
        private _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy;

        public E1_DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DeadStateConfig stateConfig, _Scripts.Enemies.EnemySpecific.Enemy1.Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateConfig)
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
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
