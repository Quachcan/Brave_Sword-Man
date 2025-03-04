using Game.Scripts.Player.Config;
using UnityEngine;

namespace Game.Scripts.Player.PlayerFiniteStateMachine
{
    public class PlayerState
    {
        protected readonly PlayerManager PlayerManager;
        protected readonly PlayerStateMachine PlayerStateMachine;
        protected readonly PlayerConfig PlayerConfig;

        protected float StartTime;
        protected bool IsAnimationFinished;    
        protected bool IsExitingState;
        
        private readonly string animBoolName;

        protected PlayerState(PlayerManager playerManager, PlayerStateMachine playerStateMachine,
            PlayerConfig playerConfig, string animBoolName)
        {
            this.PlayerManager = playerManager;
            this.PlayerStateMachine = playerStateMachine;
            this.PlayerConfig = playerConfig;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            PlayerManager.Anim.SetBool(animBoolName, true);
            DoChecks();
            StartTime = Time.time;
            //Debug.Log(animBoolName);
            IsAnimationFinished = false;
            IsExitingState = false;
        }

        public virtual void Exit()
        {
            PlayerManager.Anim.SetBool(animBoolName, false);
            IsAnimationFinished = true;
        }

        public virtual void LogicUpdate()
        {
            
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
            
        }

        public virtual void AnimationTrigger()
        {
            
        }

        public virtual void AnimationFinishTrigger() => IsAnimationFinished = true;
    }
}
