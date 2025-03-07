using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerAttackState : PlayerAbilityState
    {
        private Weapon.Weapon weapon;
        
        private float velocityToSet;
        
        private bool setVelocity;
        public PlayerAttackState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            setVelocity = false;
            
            weapon.EnterWeapon();
        }

        public override void Exit()
        {
            base.Exit();
            
            weapon.ExitWeapon();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (setVelocity)
            {
                Movement?.SetVelocityX(velocityToSet * Movement.FacingDirection);
            }
        }

        public void SetWeapon(Weapon.Weapon weapon)
        {
            this.weapon = weapon;
            weapon.InitializeWeapon(this, Core);
        }

        public void SetPlayerVelocity(float velocity)
        {
            Movement?.SetVelocityX(velocity * Movement.FacingDirection);
            
            velocityToSet = velocity;
            setVelocity = true;
        }
        
        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
            
            IsAbilityDone = true;
        }

    }
}
