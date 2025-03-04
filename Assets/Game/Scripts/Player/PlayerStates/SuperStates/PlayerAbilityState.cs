using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;

namespace Game.Scripts.Player.PlayerStates.SuperStates
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool IsAbilityDone;
        private bool isGrounded;

        protected PlayerAbilityState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            IsAbilityDone = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (IsAbilityDone)
            {
                if (isGrounded && PlayerManager.CurrentVelocity.y <= 0.01f)
                {
                    PlayerStateMachine.ChangeState(PlayerManager.IdleState);
                }
                else
                {
                    PlayerStateMachine.ChangeState(PlayerManager.InAirState);
                }
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = PlayerManager.CheckIfGrounded();
        }
    }
}
