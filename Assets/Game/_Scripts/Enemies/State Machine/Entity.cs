using Game._Scripts.Cores;
using Game._Scripts.Cores.CoreComponents;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game._Scripts.Enemies.State_Machine
{
    public class Entity : MonoBehaviour
    {
        private static readonly int YVelocity = Animator.StringToHash("yVelocity");
        public FiniteStateMachine StateMachine;

        [FormerlySerializedAs("entityConfigData")] public EntityConfig entityConfig;

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

        protected bool IsStunned;
        protected bool IsDead;

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

            if(Time.time >= lastDamageTime + entityConfig.stunRecoveryTime)
            {
                ResetStunResistance();
            }
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

        public virtual void DamageHop(float velocity)
        {
            velocityWorkspace.Set(Movement.Rb.linearVelocity.x, velocity);
            Movement.Rb.linearVelocity = velocityWorkspace;
        }

        public virtual void ResetStunResistance()
        {
            IsStunned = false;
            //currentStunResistance = entityConfig.stunResistance;
        }

        public virtual void OnDrawGizmos()
        {
            if (Core == null) return;
            Gizmos.DrawLine(CollisionSenses.wallCheck.position, CollisionSenses.wallCheck.position + (Vector3)(Vector2.right * Movement.FacingDirection * CollisionSenses.wallCheckDistance));
            Gizmos.DrawLine(CollisionSenses.LedgeCheckVertical.position, CollisionSenses.LedgeCheckVertical.position + (Vector3)(Vector2.down * CollisionSenses.WallCheckDistance));
        
            Gizmos.DrawWireSphere(CollisionSenses.GroundCheck.position, CollisionSenses.GroundCheckRadius);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityConfig.closeRangeActionDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityConfig.minAgroDistance), 0.2f);
            Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityConfig.maxAgroDistance), 0.2f);
        }
    }
}
