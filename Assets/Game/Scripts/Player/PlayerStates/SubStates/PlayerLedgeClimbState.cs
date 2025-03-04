using UnityEngine;
using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerLedgeClimbState : PlayerState
    {
        private static readonly int ClimbLedge = Animator.StringToHash("climbLedge");
        private Vector2 detectedPos;
        private Vector2 cornerPos;
        private Vector2 startPos;
        private Vector2 endPos;

        private bool isHanging;
        private bool isClimbing;
        private bool jumpInput;

        private int xInput;
        private int yInput;
        public PlayerLedgeClimbState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }
        
        public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;
        public override void Enter()
        {
            base.Enter();
            
            PlayerManager.SetVelocityZero();
            PlayerManager.transform.position = detectedPos;
            cornerPos = PlayerManager.DetermineCornerPosition();
            
            startPos.Set(cornerPos.x - (PlayerManager.FacingDirection * PlayerConfig.startOffset.x), cornerPos.y - PlayerConfig.startOffset.y);
            endPos.Set(cornerPos.x + (PlayerManager.FacingDirection * PlayerConfig.endOffset.x), cornerPos.y + PlayerConfig.endOffset.y);
            
            PlayerManager.transform.position = startPos;
        }

        public override void Exit()
        {
            base.Exit();
            
            isHanging = false;
            if (!isClimbing) return;
            PlayerManager.transform.position = endPos;
            isClimbing = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsAnimationFinished)
            {
                PlayerStateMachine.ChangeState(PlayerManager.IdleState);
            }
            else
            {
                xInput = PlayerManager.InputHandler.NormalizeInputX;
                yInput = PlayerManager.InputHandler.NormalizeInputY;
                jumpInput = PlayerManager.InputHandler.JumpInput;
            
                PlayerManager.SetVelocityZero();
                PlayerManager.transform.position = startPos;

                if ((xInput == PlayerManager.FacingDirection || yInput == 1) && isHanging && !isClimbing)
                {
                    isClimbing = true;
                    PlayerManager.Anim.SetBool(ClimbLedge, true);
                }
                else if (yInput == -1 && isHanging && !isClimbing)
                {
                    PlayerStateMachine.ChangeState(PlayerManager.InAirState);
                } 
                else if (jumpInput && !isClimbing)
                {
                    PlayerManager.WallJumpState.DetermineWallJumpDirection(true);
                    PlayerStateMachine.ChangeState(PlayerManager.WallJumpState);
                }
            }
        }

        public override void AnimationTrigger()
        {
            base.AnimationTrigger();
            
            isHanging = true;
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
            PlayerManager.Anim.SetBool(ClimbLedge, false);
        }
    }
}
