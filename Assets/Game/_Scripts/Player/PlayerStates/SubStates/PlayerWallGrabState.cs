using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;
using UnityEngine;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerWallGrabState : PlayerTouchingWallState
    {
        
        private Vector2 holdPosition;
        public PlayerWallGrabState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            if (!IsAbilityUnlocked)
            {
                PlayerStateMachine.ChangeState(PlayerManager.InAirState);
                return;
            }
            
            holdPosition = PlayerManager.transform.position;
            HoldPosition();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();


            if (IsExitingState) return;
            
            HoldPosition();
            
            if (YInput > 0)
            {
                PlayerStateMachine.ChangeState(PlayerManager.WallClimbState);
            }
            else if (YInput < 0 || !GrabInput)
            {
                PlayerStateMachine.ChangeState(PlayerManager.WallSlideState);
            }
        }

        private void HoldPosition()
        {
            PlayerManager.transform.position = holdPosition;
            
            Movement?.SetVelocityX(0f);
            Movement?.SetVelocityY(0f);
        }
    }
}
