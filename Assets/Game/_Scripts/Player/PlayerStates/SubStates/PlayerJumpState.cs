using Game._Scripts.Player;
using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private int amountOfJumpsLeft;
        
        public PlayerJumpState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : 
            base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
            amountOfJumpsLeft = playerConfig.amountOfJumps;
        }

        public override void Enter()
        {
            base.Enter();
            
            PlayerManager.InputHandler.UseJumpInput();
            Movement?.SetVelocityY(PlayerConfig.jumpVelocity);
            IsAbilityDone = true;
            amountOfJumpsLeft--;
            PlayerManager.InAirState.SetIsJumping();
        }

        public bool CanJump()
        {
            if(amountOfJumpsLeft > 0) return true;
            return false;
        }
        
        public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = PlayerConfig.amountOfJumps;
        
        public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;
    }
}
