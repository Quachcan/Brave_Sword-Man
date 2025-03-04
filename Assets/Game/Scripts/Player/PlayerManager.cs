using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SubStates;
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
        public PlayerDashState DashState { get; private set; }
        #endregion
        
        #region Components 
        public Animator Anim { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        [SerializeField]
        private PlayerConfig config;
        #endregion

        #region CheckTransform
        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform wallCheck;
        [SerializeField] private Transform ledgeCheck;
        #endregion
        
        #region Other Variables
        public Vector2 CurrentVelocity { get; private set; }
        public int FacingDirection { get; private set; }
        private Vector2 workSpace; //Temporary variable
        #endregion
        
        private void Awake()
        {
            
        }

        public void Initialize()
        {
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
            DashState = new PlayerDashState(this,  StateMachine, config, "dash" );
            
            Anim = GetComponent<Animator>();
            InputHandler = GetComponent<PlayerInputHandler>();
            Rb = GetComponent<Rigidbody2D>();
            
            FacingDirection = 1;
            
            StateMachine.Initialize(IdleState);
        }

        #region Unity Callbacks Functions
        private void Update()
        {
            CurrentVelocity = Rb.linearVelocity;
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        #endregion

        #region Set Functions

        public void SetVelocityZero()
        {
            Rb.linearVelocity = Vector2.zero;
            CurrentVelocity = Vector2.zero;
        }
        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {
            angle.Normalize();
            workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
            Rb.linearVelocity = workSpace;
            CurrentVelocity = workSpace;
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            workSpace = velocity * direction;
            Rb.linearVelocity = workSpace;
            CurrentVelocity = workSpace;
        }
        
        public void SetVelocityX(float velocity)
        {
            //Update new value for workSpace
            workSpace.Set(velocity, CurrentVelocity.y);   
            Rb.linearVelocity = workSpace;
            CurrentVelocity = workSpace;
        }

        public void SetVelocityY(float velocity)
        {
            //Update new value for workSpace
            workSpace.Set(CurrentVelocity.x, velocity);
            Rb.linearVelocity = workSpace;
            CurrentVelocity = workSpace;
        }
        #endregion

        #region Check Functions

        public bool CheckIfGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, config.groundCheckRadius, config.whatIsGround);
        }

        public bool CheckIfTouchingWall()
        {
            return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, config.wallCheckDistance, config.whatIsGround);
        }

        public bool CheckIfTouchingLedge()
        {
            return Physics2D.Raycast(ledgeCheck.position, Vector2.right * FacingDirection, config.wallCheckDistance, config.whatIsGround);
        }
        
        public bool CheckIfTouchingWallBack()
        {
            return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, config.wallCheckDistance, config.whatIsGround);
        }

        public void CheckIfShouldFlip(int xInput)
        {
            if (xInput != 0 && xInput != FacingDirection)
            {
                FlipPlayer();
            }
        }
        

        #endregion

        #region Other Functions

        public Vector2 DetermineCornerPosition()
        {
            RaycastHit2D xHit = Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, config.wallCheckDistance, config.whatIsGround);
            float xDist= xHit.distance;
            workSpace.Set(xDist * FacingDirection, 0f);
            RaycastHit2D yHit = Physics2D.Raycast(ledgeCheck.position + (Vector3)(workSpace), Vector2.down, ledgeCheck.position.y - wallCheck.position.y, config.whatIsGround);
            float yDist = yHit.distance;
            
            workSpace.Set(wallCheck.position.x + (xDist * FacingDirection), ledgeCheck.position.y - yDist);
            return workSpace;
        }
        
        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
        
        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        private void FlipPlayer()
        {
            FacingDirection *= -1;
            transform.Rotate(0f, 180f, 0f);
        }

        #endregion
    }
}
