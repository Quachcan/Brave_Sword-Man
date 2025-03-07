using Game._Scripts.Cores.CoreComponents;
using Game.Scripts.Cores.CoreComponents;
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

        protected CollisionSenses CollisionSenses => collisionSense ?? Core.GetCoreComponent(ref collisionSense);
        private CollisionSenses collisionSense;
        
        protected Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private Movement movement;

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

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            xInput = PlayerManager.InputHandler.NormalizeInputX;
            jumpInput = PlayerManager.InputHandler.JumpInput;
            jumpInputStop = PlayerManager.InputHandler.JumpInputStop;
            grabInput = PlayerManager.InputHandler.GrabInput;
            
            CheckJumpMultiplier();

            if (PlayerManager.InputHandler.AttackInputs[(int)CombatInputs.Primary])
            {
                PlayerStateMachine.ChangeState(PlayerManager.PrimaryAttackState);
            }
            else if (PlayerManager.InputHandler.AttackInputs[(int)CombatInputs.Secondary])
            {
                PlayerStateMachine.ChangeState(PlayerManager.SecondaryAttackState);
            }
            else if (isGrounded && Movement.CurrentVelocity.y <= 0f)
            {
                PlayerStateMachine.ChangeState(PlayerManager.LandState);
            }
            else if (isTouchingWall && !isTouchingLedge && !isGrounded)
            {
                PlayerStateMachine.ChangeState(PlayerManager.LedgeClimbState);
            }
            else if (jumpInput && (isTouchingWall || isTouchingWallBack))
            {
                isTouchingWall = CollisionSenses.WallFront;
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
            else if (isTouchingWall && xInput == Movement.FacingDirection && Movement.CurrentVelocity.y <= 0)
            {
                PlayerStateMachine.ChangeState(PlayerManager.WallSlideState);
            }
            else 
            {
                Movement?.CheckIfShouldFlip(xInput);
                Movement?.SetVelocityX(PlayerConfig.movementVelocity * xInput);
                
                PlayerManager.Anim.SetFloat(YVelocity, Movement.CurrentVelocity.y);
                PlayerManager.Anim.SetFloat(XVelocity, Mathf.Abs(Movement.CurrentVelocity.x) );
            }
        }

        private void CheckJumpMultiplier()
        {
            if (!isJumping) return;
            if (jumpInputStop)
            {
                Movement?.SetVelocityY(Movement.CurrentVelocity.y * PlayerConfig.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if(Movement.CurrentVelocity.y < 0f)
            {
                isJumping = false;
            }
        }
        
        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = CollisionSenses.Ground;
            isTouchingWall = CollisionSenses.WallFront;
            isTouchingWallBack = CollisionSenses.WallBack;
            isTouchingLedge = CollisionSenses.LedgeHorizontal;

            if (isTouchingWall && !isTouchingLedge)
            {
                PlayerManager.LedgeClimbState.SetDetectedPosition(PlayerManager.transform.position);
            }
        }
        
        public void SetIsJumping() => isJumping = true;
    }
}
