using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerMoveState : PlayerGroundedState
    {
        public PlayerMoveState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : 
            base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
            
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            Movement?.CheckIfShouldFlip(XInput);
            
            Movement?.SetVelocityX(PlayerConfig.movementVelocity * XInput);
            
            if(IsExitingState) return;
            if (XInput == 0)
            {
                PlayerStateMachine.ChangeState(PlayerManager.IdleState);
            }
            else if (YInput == -1)
            {
                PlayerStateMachine.ChangeState(PlayerManager.CrouchMoveState);
            }
        }
    }
}
