using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;

namespace Game.Scripts.Player.PlayerStates.SuperStates
{
    public class PlayerGroundedState : PlayerState
    {
        protected int XInput;
        protected int YInput;
        
        protected bool IsTouchingCeiling;

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
            PlayerManager.DodgeState.ResetCanDash();
        }
        

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            XInput = PlayerManager.InputHandler.NormalizeInputX; 
            YInput = PlayerManager.InputHandler.NormalizeInputY;
            jumpInput = PlayerManager.InputHandler.JumpInput;
            grabInput = PlayerManager.InputHandler.GrabInput;
            dashInput = PlayerManager.InputHandler.DodgeInput;

            if (PlayerManager.InputHandler.AttackInputs[(int)CombatInputs.Primary] && !IsTouchingCeiling)
            {
                PlayerStateMachine.ChangeState(PlayerManager.PrimaryAttackState);
            }
            else if (PlayerManager.InputHandler.AttackInputs[(int)CombatInputs.Secondary] && !IsTouchingCeiling)
            {
                PlayerStateMachine.ChangeState(PlayerManager.SecondaryAttackState);
            }
            else if (jumpInput && PlayerManager.JumpState.CanJump())
            {
                PlayerStateMachine.ChangeState(PlayerManager.JumpState);
            }
            else if(!isGrounded)
            {
                PlayerManager.JumpState.DecreaseAmountOfJumpsLeft();
                PlayerStateMachine.ChangeState(PlayerManager.InAirState);
            }
            else if (isTouchingWall && grabInput && isTouchingLedge)
            {
                PlayerStateMachine.ChangeState(PlayerManager.WallGrabState);
            }
            else if (isGrounded && dashInput && !IsTouchingCeiling)
            {
                PlayerStateMachine.ChangeState(PlayerManager.DodgeState);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();
            
            isGrounded = Core.CollisionSenses.Ground;
            isTouchingWall = Core.CollisionSenses.WallFront;
            isTouchingLedge = Core.CollisionSenses.LedgeHorizontal;
            IsTouchingCeiling = Core.CollisionSenses.Ceiling;
        }
    }
}
