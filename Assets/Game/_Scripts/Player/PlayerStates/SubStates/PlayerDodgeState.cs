using Game._Scripts.Player;
using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;
using UnityEngine;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerDodgeState : PlayerAbilityState
    {
        public bool CanDodge {get; private set;}
        
        private float lastDodgeTime;
        private float dodgeStartTime;
        
        private Vector2 dodgeDirection;
        
        private bool isGrounded;
        private bool isTouchingCeiling;
        
        public PlayerDodgeState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : 
            base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            if (!isGrounded)
            {
                PlayerStateMachine.ChangeState(PlayerManager.InAirState);
                return;
            }
            
            CanDodge = false;
            PlayerManager.InputHandler.UseDashInput();
            dodgeDirection = Vector2.right * Movement.FacingDirection;
            dodgeStartTime = Time.time;
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
            
            
            if(Time.time >= dodgeStartTime + PlayerConfig.dodgeDuration)
            {
                PlayerManager.Rb.linearDamping = 0f;
                lastDodgeTime = Time.time;
                
                if (isTouchingCeiling)
                {
                    PlayerStateMachine.ChangeState(PlayerManager.CrouchIdleState);
                }
                
                IsAbilityDone = true;
            }
            else if (isGrounded)
            {
                PlayerManager.Rb.linearDamping = PlayerConfig.drag;
                Movement?.SetVelocity(PlayerConfig.dodgeVelocity, dodgeDirection);
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();
            
            isGrounded = CollisionSenses.Ground;
            isTouchingCeiling = CollisionSenses.Ceiling;
        }

        public bool CheckIfCanDash()
        {
            return CanDodge && isGrounded && Time.time >= lastDodgeTime + PlayerConfig.dashCooldown;
        }
        
        public void ResetCanDash() => CanDodge = true;
    }
}
