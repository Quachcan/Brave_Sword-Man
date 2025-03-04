using System;
using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;
using UnityEngine;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerDashState : PlayerAbilityState
    {
        public bool CanDash {get; private set;}
        
        private float lastDashTime;
        private float dashStartTime;
        
        private Vector2 dashDirection;
        
        private bool isGrounded;
        
        public PlayerDashState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : 
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
            
            CanDash = false;
            PlayerManager.InputHandler.UseDashInput();
            dashDirection = Vector2.right * PlayerManager.FacingDirection;
            dashStartTime = Time.time;
            
        }

        public override void Exit()
        {
            base.Exit();
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if(Time.time >= dashStartTime + PlayerConfig.dashDuration)
            {
                PlayerManager.Rb.linearDamping = 0f;
                IsAbilityDone = true;
                lastDashTime = Time.time;
            }
            else if (isGrounded)
            {
                PlayerManager.Rb.linearDamping = PlayerConfig.drag;
                PlayerManager.SetVelocity(PlayerConfig.dashVelocity, dashDirection);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            PlayerManager.SetVelocity(PlayerConfig.dashVelocity, dashDirection, 1);
        }

        public override void DoChecks()
        {
            base.DoChecks();
            
            isGrounded = PlayerManager.CheckIfGrounded();
        }

        public bool CheckIfCanDash()
        {
            return CanDash && isGrounded && Time.time >= lastDashTime + PlayerConfig.dashCooldown;
        }
        
        public void ResetCanDash() => CanDash = true;
    }
}
