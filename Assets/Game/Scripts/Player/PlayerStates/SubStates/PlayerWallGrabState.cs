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
            
            holdPosition = PlayerManager.transform.position;
            
            HoldPosition();
        }

        public override void Exit()
        {
            base.Exit();
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
            
            PlayerManager.SetVelocityX(0f);
            PlayerManager.SetVelocityY(0f);
        }
        
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
        }
    }
}
