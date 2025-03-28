using Game._Scripts.Player;
using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : 
            base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Movement?.SetVelocityX(0f);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if(IsExitingState) return;
            if (XInput != 0)
            {
                PlayerStateMachine.ChangeState(PlayerManager.MoveState);
            }
            else if (YInput == -1)
            {
                PlayerStateMachine.ChangeState(PlayerManager.CrouchIdleState);
            }
        }
    }
}
