using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;

namespace Game.Scripts.Player.PlayerStates.SuperStates
{
    public class PlayerTouchingWallState : PlayerState
    {
        protected bool IsGrounded;
        protected bool IsTouchingWall;
        protected bool GrabInput;
        protected bool JumpInput;
        protected bool IsTouchingLedge;
        protected int XInput;
        protected int YInput;
        protected PlayerTouchingWallState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            XInput = PlayerManager.InputHandler.NormalizeInputX;
            YInput = PlayerManager.InputHandler.NormalizeInputY;
            GrabInput = PlayerManager.InputHandler.GrabInput;
            JumpInput = PlayerManager.InputHandler.JumpInput;

            if (JumpInput)
            {
                PlayerManager.WallJumpState.DetermineWallJumpDirection(IsTouchingWall);
                PlayerStateMachine.ChangeState(PlayerManager.WallJumpState);
            }
            else if (IsGrounded && !GrabInput)
            {
                PlayerStateMachine.ChangeState(PlayerManager.IdleState);
            }
            else if (!IsTouchingWall || (XInput != Core.Movement.FacingDirection && !GrabInput))
            {
                PlayerStateMachine.ChangeState(PlayerManager.InAirState);
            }
            else if (IsTouchingWall && !IsTouchingLedge)
            {
                PlayerStateMachine.ChangeState(PlayerManager.LedgeClimbState);
            }
        }
        
        public override void DoChecks()
        {
            base.DoChecks();
            
            IsGrounded = Core.CollisionSenses.Ground;
            IsTouchingWall = Core.CollisionSenses.WallFront;
            IsTouchingLedge = Core.CollisionSenses.LedgeHorizontal;

            if (!IsTouchingLedge && IsTouchingWall)
            {
                PlayerManager.LedgeClimbState.SetDetectedPosition(PlayerManager.transform.position);
            }
        }
    }
}
