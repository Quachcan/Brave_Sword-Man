

using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerWallSlideState : PlayerTouchingWallState
    {
        public PlayerWallSlideState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                Movement?.SetVelocityY(-PlayerConfig.wallSlideVelocity);

                if (GrabInput && YInput == 0)
                {
                    PlayerStateMachine.ChangeState(PlayerManager.WallGrabState);
                }
            }
        }
    }
}
