﻿using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States.Configs;
using Game._Scripts.Manager;
using Game.Scripts.Enemies.EnemySpecific.Enemy1;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

namespace Game._Scripts.Enemies.EnemySpecific.Enemy1
{
    public class Enemy1 : Entity
    {
        private Stats Stats => stats ?? Core.GetCoreComponent(ref stats);
        private Stats stats;
        
        public E1_IdleState IdleState { get; private set; }
        public E1_MoveState MoveState { get; private set; }
        public E1_PlayerDetectedState PlayerDetectedState { get; private set; }
        public E1_ChargeState ChargeState { get; private set; }
        public E1_LookForPlayerState LookForPlayerState { get; private set; }
        public E1MeleeAttackState MeleeAttackState { get; private set; }
        public E1_StunState StunState { get; private set; }
        public E1_DeadState DeadState { get; private set; }

        [SerializeField] private IdleStateConfig idleStateConfig;
        [SerializeField] private MoveStateConfig moveStateConfig;
        [SerializeField] private PlayerDetectedConfig playerDetectedConfig;
        [SerializeField] private ChargeStateConfig chargeStateConfig;
        [SerializeField] private LookForPlayerConfig lookForPlayerStateConfig;
        [SerializeField] private MeleeAttackConfig meleeAttackStateConfig;
        [SerializeField] private StunStateConfig stunStateConfig;
        [SerializeField] private DeadStateConfig deadStateConfig;


        [SerializeField]
        private Transform meleeAttackPosition;

        public override void Awake()
        {
            base.Awake();
            
            MoveState = new E1_MoveState(this, StateMachine, "move", moveStateConfig, this);
            IdleState = new E1_IdleState(this, StateMachine, "idle", idleStateConfig, this);
            PlayerDetectedState = new E1_PlayerDetectedState(this, StateMachine, "playerDetected", playerDetectedConfig, this);
            ChargeState = new E1_ChargeState(this, StateMachine, "charge", chargeStateConfig, this);
            LookForPlayerState = new E1_LookForPlayerState(this, StateMachine, "lookForPlayer", lookForPlayerStateConfig, this);
            MeleeAttackState = new E1MeleeAttackState(this, StateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateConfig, this);
            StunState = new E1_StunState(this, StateMachine, "stun", stunStateConfig, this);
            DeadState = new E1_DeadState(this, StateMachine, "dead", deadStateConfig, this);
        }

        public void Start()
        {
            EnemyManager.Instance.RegisterEnemy(this);
            StateMachine.Initialize(MoveState);        
        }

        public override void ResetState()
        {
            base.ResetState();
            if (Stats != null)
            {
                Stats.RestoreFullHealth();
            }
            
            StateMachine.Initialize(IdleState);
        }
    }
}
