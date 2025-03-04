using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;

namespace Game.Scripts.Player.PlayerStates.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        protected int XInput;

        private bool jumpInput;
        private bool grabInput;
        private bool isGrounded;
        private bool isTouchingWall;
        private bool isTouchingLedge;
        private bool dashInput;

        protected PlayerGroundedState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
            
        }

        public override void Enter()
        {
            base.Enter(); 
            PlayerManager.JumpState.ResetAmountOfJumpsLeft();
            PlayerManager.DashState.ResetCanDash();
        }
        

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            XInput = PlayerManager.InputHandler.NormalizeInputX; 
            jumpInput = PlayerManager.InputHandler.JumpInput;
            grabInput = PlayerManager.InputHandler.GrabInput;
            dashInput = PlayerManager.InputHandler.DashInput;

            if (jumpInput && PlayerManager.JumpState.CanJump())
            {
                PlayerStateMachine.ChangeState(PlayerManager.JumpState);
            }else if(!isGrounded)
            {
                PlayerManager.JumpState.DecreaseAmountOfJumpsLeft();
                PlayerStateMachine.ChangeState(PlayerManager.InAirState);
            }else if (isTouchingWall && grabInput && isTouchingLedge)
            {
                PlayerStateMachine.ChangeState(PlayerManager.WallGrabState);
            }
            else if (isGrounded && dashInput)
            {
                PlayerStateMachine.ChangeState(PlayerManager.DashState);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();
            
            isGrounded = PlayerManager.CheckIfGrounded();
            isTouchingWall = PlayerManager.CheckIfTouchingWall();
            isTouchingLedge = PlayerManager.CheckIfTouchingLedge();
        }
    }
}
