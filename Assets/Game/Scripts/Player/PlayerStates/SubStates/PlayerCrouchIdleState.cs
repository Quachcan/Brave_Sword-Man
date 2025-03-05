using Game.Scripts.Player.Config;
using Game.Scripts.Player.PlayerFiniteStateMachine;
using Game.Scripts.Player.PlayerStates.SuperStates;
using UnityEngine;

namespace Game.Scripts.Player.PlayerStates.SubStates
{
    public class PlayerCrouchIdleState : PlayerGroundedState
    {
        public PlayerCrouchIdleState(PlayerManager playerManager, PlayerStateMachine playerStateMachine, PlayerConfig playerConfig, string animBoolName) : base(playerManager, playerStateMachine, playerConfig, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            Core.Movement.SetVelocityZero();
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
            
            if(IsExitingState) return;
            if (XInput != 0)
            {
                PlayerStateMachine.ChangeState(PlayerManager.CrouchMoveState);
            }
            else if (YInput != -1 && !IsTouchingCeiling)
            {
                PlayerStateMachine.ChangeState(PlayerManager.IdleState);
            }
        }
    }
}
