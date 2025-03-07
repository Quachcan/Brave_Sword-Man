using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerWallClimbState : PlayerTouchingWallState
    {
        public PlayerWallClimbState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsExitingState) return;
            Movement?.SetVelocityY(PlayerConfig.wallClimbVelocity);

            if (YInput != 1)
            {
                PlayerStateMachine.ChangeState(PlayerManager.WallGrabState);
            }
        }
    }
}
