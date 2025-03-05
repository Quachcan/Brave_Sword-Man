using Game.Scripts.Cores;
using UnityEngine;

namespace Game.Scripts.Enemies.State_Machine
{
    public class State
    {
        protected FiniteStateMachine StateMachine;
        protected Entity Entity;
        protected Core Core;    

        public float StartTime { get; protected set; }

        protected string AnimBoolName;

        public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
        {
            this.Entity = entity;
            this.StateMachine = stateMachine;
            this.AnimBoolName = animBoolName;
            Core = this.Entity.Core;
        }

        public virtual void Enter()
        {
            StartTime = Time.time;
            Entity.anim.SetBool(AnimBoolName, true);
            DoChecks();
        }

        public virtual void Exit()
        {
            Entity.anim.SetBool(AnimBoolName, false);
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
    }
}
