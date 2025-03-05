using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;
namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerCrouchMoveState : PlayerGroundedState
    {
        public PlayerCrouchMoveState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            PlayerManager.SetColliderHeight(PlayerConfig.crouchColliderHeight);
        }

        public override void Exit()
        {
            base.Exit();
            PlayerManager.SetColliderHeight(PlayerConfig.standColliderHeight);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if(IsExitingState) return;
            Core.Movement.SetVelocityX(PlayerConfig.crouchMovementVelocity * Core.Movement.FacingDirection);
            Core.Movement.CheckIfShouldFlip(XInput);
            if (XInput == 0)
            {
                PlayerStateMachine.ChangeState(PlayerManager.CrouchIdleState);
            }
            else if (YInput != -1 && !IsTouchingCeiling)
            {
                PlayerStateMachine.ChangeState(PlayerManager.MoveState);
            }
        }
    }
}
