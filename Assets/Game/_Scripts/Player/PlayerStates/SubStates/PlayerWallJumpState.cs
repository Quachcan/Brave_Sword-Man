using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;
using UnityEngine;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerWallJumpState : PlayerAbilityState
    {
        private static readonly int XVelocity = Animator.StringToHash("xVelocity");
        private static readonly int YVelocity = Animator.StringToHash("yVelocity");
        private int wallJumpDirection;
        public PlayerWallJumpState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : 
            base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            if (!IsAbilityUnlocked)
            {
                PlayerStateMachine.ChangeState(PlayerManager.IdleState);
                return;
            }
            
            PlayerManager.InputHandler.UseJumpInput();
            PlayerManager.JumpState.ResetAmountOfJumpsLeft();
            Movement?.SetVelocity(PlayerConfig.wallJumpVelocity, PlayerConfig.wallJumpAngle, wallJumpDirection);
            Movement?.CheckIfShouldFlip(wallJumpDirection);
            PlayerManager.JumpState.DecreaseAmountOfJumpsLeft();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            PlayerManager.Anim.SetFloat(YVelocity, Movement.CurrentVelocity.y);
            PlayerManager.Anim.SetFloat(XVelocity, Mathf.Abs(Movement.CurrentVelocity.x));

            if (Time.time >= StartTime + PlayerConfig.wallJumpTime)
            {
                IsAbilityDone = true;
            }
        }
        public void DetermineWallJumpDirection(bool isTouchingWall)
        {
            if (isTouchingWall)
            {
                wallJumpDirection = -Movement.FacingDirection;
            }
            else
            {
                wallJumpDirection = Movement.FacingDirection;
            }
        }
    }
}
