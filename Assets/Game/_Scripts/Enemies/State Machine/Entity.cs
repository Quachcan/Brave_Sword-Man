﻿using Game._Scripts.Cores;
using Game._Scripts.Cores.CoreComponents;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game._Scripts.Enemies.State_Machine
{
    public class Entity : MonoBehaviour
    {
        private static readonly int YVelocity = Animator.StringToHash("yVelocity");

        protected FiniteStateMachine StateMachine;

        public EntityConfig entityConfig;

        public Animator Anim { get; private set; }    
        public AnimationToStatemachine Atsm { get; private set; }
        public int LastDamageDirection { get; private set; }
        public Core Core { get; private set; }

        private Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private Movement movement;
        
        protected CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
        private CollisionSenses collisionSenses;
        
        [SerializeField]
        private Transform playerCheck;
        
        private float lastDamageTime;

        private Vector2 velocityWorkspace;
        
        public virtual void Awake()
        {
            Core = GetComponentInChildren<Core>();
        
            Anim = GetComponent<Animator>();
            Atsm = GetComponent<AnimationToStatemachine>();

            StateMachine = new FiniteStateMachine();
        }

        public virtual void Update()
        {
            Core.LogicUpdate();
            StateMachine.CurrentState.LogicUpdate();

            Anim.SetFloat(YVelocity, Movement.Rb.linearVelocity.y);
        }

        public virtual void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }  

        public virtual bool CheckPlayerInMinAgroRange()
        {
            return Physics2D.Raycast(playerCheck.position, transform.right, entityConfig.minAgroDistance, entityConfig.whatIsPlayer);
        }

        public virtual bool CheckPlayerInMaxAgroRange()
        {
            return Physics2D.Raycast(playerCheck.position, transform.right, entityConfig.maxAgroDistance, entityConfig.whatIsPlayer);
        }

        public virtual bool CheckPlayerInCloseRangeAction()
        {
            return Physics2D.Raycast(playerCheck.position, transform.right, entityConfig.closeRangeActionDistance, entityConfig.whatIsPlayer);
        }

        public virtual void ResetState()
        {
            
        }

        //public virtual void OnDrawGizmos()
        //{
        //    Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityConfig.closeRangeActionDistance), 0.2f);
        //    Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityConfig.minAgroDistance), 0.2f);
        //    Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityConfig.maxAgroDistance), 0.2f);
        //}
    }
}
