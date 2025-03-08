using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.EnemySpecific.Enemy3
{
    public class Enemy3 : Entity
    {
        public E3MoveState MoveState { get; private set; }
        public E3IdleState IdleState { get; private set; }
        public E3PlayerDetectedState PlayerDetectedState { get; private set; }
        public E3RangeAttackState RangeAttackState  { get; private set; }
        
        [SerializeField] private IdleStateConfig  idleStateConfig;
        [SerializeField] private MoveStateConfig moveStateConfig;
        [SerializeField] private PlayerDetectedConfig  playerDetectedConfig;
        [SerializeField] private RangedAttackStateConfig rangedAttackStateConfig;

        [SerializeField] private Transform rangeAttackPosition;

        public override void Awake()
        {
            base.Awake();
            
            IdleState = new E3IdleState(this, StateMachine, "idle",  idleStateConfig, this);
            MoveState = new E3MoveState(this, StateMachine, "move", moveStateConfig, this);
            PlayerDetectedState = new E3PlayerDetectedState(this, StateMachine, "player_detected", playerDetectedConfig, this);
            RangeAttackState = new E3RangeAttackState(this, StateMachine, "rangeAttack", rangeAttackPosition,
                rangedAttackStateConfig, this);
            
            StateMachine.Initialize(MoveState);
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            
        }
    }
}
