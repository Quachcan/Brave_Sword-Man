using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerInAirState : PlayerState
    {
        private static readonly int YVelocity = Animator.StringToHash("yVelocity");
        private static readonly int XVelocity = Animator.StringToHash("xVelocity");

        #region Input
        private int xInput;
        private bool isGrounded;
        private bool jumpInput;
        private bool jumpInputStop;
        private bool grabInput;
        #endregion
        
        #region Check
        private bool isJumping;
        private bool isTouchingWall;
        private bool isTouchingWallBack;
        private bool isTouchingLedge;
        #endregion
        public PlayerInAirState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : 
            base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
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
            
            xInput = PlayerManager.InputHandler.NormalizeInputX;
            jumpInput = PlayerManager.InputHandler.JumpInput;
            jumpInputStop = PlayerManager.InputHandler.JumpInputStop;
            grabInput = PlayerManager.InputHandler.GrabInput;
            
            CheckJumpMultiplier();

            if (isGrounded && PlayerManager.CurrentVelocity.y <= 0f)
            {
                PlayerStateMachine.ChangeState(PlayerManager.LandState);
            }
            else if (isTouchingWall && !isTouchingLedge && !isGrounded)
            {
                PlayerStateMachine.ChangeState(PlayerManager.LedgeClimbState);
            }
            else if (jumpInput && (isTouchingWall || isTouchingWallBack))
            {
                isTouchingWall = PlayerManager.CheckIfTouchingWall();
                PlayerManager.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
                PlayerStateMachine.ChangeState(PlayerManager.WallJumpState);
            }
            else if (jumpInput && PlayerManager.JumpState.CanJump())
            {
                PlayerStateMachine.ChangeState(PlayerManager.JumpState);
            }
            else if (isTouchingWall && grabInput && isTouchingLedge)
            {
                PlayerStateMachine.ChangeState(PlayerManager.WallGrabState);
            }
            else if (isTouchingWall && xInput == PlayerManager.FacingDirection && PlayerManager.CurrentVelocity.y <= 0)
            {
                PlayerStateMachine.ChangeState(PlayerManager.WallSlideState);
            }
            else 
            {
                PlayerManager.CheckIfShouldFlip(xInput);
                PlayerManager.SetVelocityX(PlayerConfig.movementVelocity * xInput);
                
                PlayerManager.Anim.SetFloat(YVelocity, PlayerManager.CurrentVelocity.y);
                PlayerManager.Anim.SetFloat(XVelocity, Mathf.Abs(PlayerManager.CurrentVelocity.x) );
            }
        }

        private void CheckJumpMultiplier()
        {
            if (!isJumping) return;
            if (jumpInputStop)
            {
                PlayerManager.SetVelocityY(PlayerManager.CurrentVelocity.y * PlayerConfig.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if(PlayerManager.CurrentVelocity.y < 0f)
            {
                isJumping = false;
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = PlayerManager.CheckIfGrounded();
            isTouchingWall = PlayerManager.CheckIfTouchingWall();
            isTouchingWallBack = PlayerManager.CheckIfTouchingWallBack();
            isTouchingLedge = PlayerManager.CheckIfTouchingLedge();

            if (isTouchingWall && !isTouchingLedge)
            {
                PlayerManager.LedgeClimbState.SetDetectedPosition(PlayerManager.transform.position);
            }
        }
        
        public void SetIsJumping() => isJumping = true;
    }
}
