using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SubStates;
using Game.Scripts.Player.PlayerStates.SuperStates;
using Game.Scripts.Cores;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerManager : MonoBehaviour
    {
        #region State Variables
        public PlayerStateMachine StateMachine {get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
        public PlayerWallSlideState WallSlideState { get; private set; }
        public PlayerWallGrabState WallGrabState { get; private set; }
        public PlayerWallClimbState WallClimbState { get; private set; }
        public PlayerWallJumpState WallJumpState { get; private set; }
        public PlayerLedgeClimbState  LedgeClimbState { get; private set; }
        public PlayerDodgeState DodgeState { get; private set; }
        public PlayerCrouchIdleState CrouchIdleState { get; private set; }
        public PlayerCrouchMoveState CrouchMoveState { get; private set; }
        public PlayerAttackState PrimaryAttackState { get; private set; }
        public PlayerAttackState SecondaryAttackState { get; private set; }
        #endregion
        
        #region Components 
        public Cores.Core Core { get; private set; }
        public Animator Anim { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        public BoxCollider2D MoveCollider { get; private set; }
        public PlayerInventory Inventory { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        [SerializeField]
        private PlayerConfig config;
        #endregion

        
        
        #region Other Variables
        //public Vector2 CurrentVelocity { get; private set; }
        //public int FacingDirection { get; private set; }
        private Vector2 workSpace; //Temporary variable
        #endregion

        public void Initialize()
        {
            Core = GetComponentInChildren<Cores.Core>();
            
            StateMachine = new PlayerStateMachine();
            
            IdleState = new PlayerIdleState(this, StateMachine, config, "Idle" );
            MoveState = new PlayerMoveState(this, StateMachine, config, "Move" );
            JumpState = new PlayerJumpState(this, StateMachine, config, "inAir" );
            InAirState = new PlayerInAirState(this, StateMachine, config, "inAir" );
            LandState = new PlayerLandState(this, StateMachine, config, "land" );
            WallSlideState = new PlayerWallSlideState(this, StateMachine, config, "wallSlide" );
            WallGrabState = new PlayerWallGrabState(this, StateMachine, config, "wallGrab" );
            WallClimbState = new PlayerWallClimbState(this, StateMachine, config, "wallClimb" );
            WallJumpState = new PlayerWallJumpState(this, StateMachine, config, "inAir" );
            LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, config, "ledgeClimbState" );
            DodgeState = new PlayerDodgeState(this,  StateMachine, config, "dodge" );
            CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, config, "crouchIdle" );
            CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, config, "crouchMove" );
            PrimaryAttackState = new PlayerAttackState(this, StateMachine, config, "attack");
            SecondaryAttackState = new PlayerAttackState(this, StateMachine, config, "attack");
            
            Anim = GetComponent<Animator>();
            InputHandler = GetComponent<PlayerInputHandler>();
            Rb = GetComponent<Rigidbody2D>();
            MoveCollider = GetComponent<BoxCollider2D>();
            Inventory = GetComponent<PlayerInventory>();
            
            //FacingDirection = 1;
            
            PrimaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.Primary]);
            //SecondaryAttackState.SetWeapon(Inventory.weapons[(int)CombatInputs.Primary]);
            
            StateMachine.Initialize(IdleState);
        }

        #region Unity Callbacks Functions
        private void Update()
        {
            Core.LogicUpdate();
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        #endregion

        

        #region Other Functions

        public void SetColliderHeight(float height)
        {
            var center = MoveCollider.offset;
            workSpace.Set(MoveCollider.size.x, height);
            
            center.y += (height - MoveCollider.size.y)/ 2;
            
            MoveCollider.size = workSpace; 
            MoveCollider.offset = center;
        }
        
        
        
        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
        
        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

        #endregion
    }
}
