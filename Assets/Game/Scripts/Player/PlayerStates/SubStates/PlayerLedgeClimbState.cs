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
        private Vector2 workSpace;

        private bool isHanging;
        private bool isClimbing;
        private bool jumpInput;
        private bool isTouchingCeiling;

        private int xInput;
        private int yInput;
        public PlayerLedgeClimbState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }
        
        public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;

        public void CheckForSpace()
        {
            isTouchingCeiling = Physics2D.Raycast(cornerPos + (Vector2.up * 0.015f) + (Vector2.right * (Core.Movement.FacingDirection * 0.015f)),
                Vector2.up, 
                PlayerConfig.standColliderHeight,
                Core.CollisionSenses.WhatIsGround);
        }
        public override void Enter()
        {
            base.Enter();
            
            Core.Movement.SetVelocityZero();
            PlayerManager.transform.position = detectedPos;
            cornerPos = DetermineCornerPosition();
            
            startPos.Set(cornerPos.x - (Core.Movement.FacingDirection * PlayerConfig.startOffset.x), cornerPos.y - PlayerConfig.startOffset.y);
            endPos.Set(cornerPos.x + (Core.Movement.FacingDirection * PlayerConfig.endOffset.x), cornerPos.y + PlayerConfig.endOffset.y);
            
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
                if (isTouchingCeiling)
                {
                    PlayerStateMachine.ChangeState(PlayerManager.CrouchIdleState);
                }
                else
                {
                    PlayerStateMachine.ChangeState(PlayerManager.IdleState);
                }
            }
            else
            {
                xInput = PlayerManager.InputHandler.NormalizeInputX;
                yInput = PlayerManager.InputHandler.NormalizeInputY;
                jumpInput = PlayerManager.InputHandler.JumpInput;
            
                Core.Movement.SetVelocityZero();
                PlayerManager.transform.position = startPos;

                if ((xInput == Core.Movement.FacingDirection || yInput == 1) && isHanging && !isClimbing)
                {
                    CheckForSpace();
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
        
        private Vector2 DetermineCornerPosition()
        {
            RaycastHit2D xHit = Physics2D.Raycast(Core.CollisionSenses.WallCheck.position, Vector2.right * Core.Movement.FacingDirection, Core.CollisionSenses.WallCheckDistance, Core.CollisionSenses.WhatIsGround);
            float xDist= xHit.distance;
            workSpace.Set((xDist + 0.015f) * Core.Movement.FacingDirection, 0f);
            RaycastHit2D yHit = Physics2D.Raycast(Core.CollisionSenses.LedgeCheckHorizontal.position + (Vector3)(workSpace), Vector2.down, Core.CollisionSenses.LedgeCheckHorizontal.position.y - Core.CollisionSenses.WallCheck.position.y + 0.015f, Core.CollisionSenses.WhatIsGround);
            float yDist = yHit.distance;
            workSpace.Set(Core.CollisionSenses.WallCheck.position.x + (xDist * Core.Movement.FacingDirection), Core.CollisionSenses.LedgeCheckHorizontal.position.y - yDist);
            return workSpace;
        }
    }
}
