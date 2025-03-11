using Game._Scripts.Cores;
using UnityEngine;

namespace Game._Scripts.Enemies.State_Machine
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
            Entity.Anim.SetBool(AnimBoolName, true);
            DoChecks();
        }

        public virtual void Exit()
        {
            Entity.Anim.SetBool(AnimBoolName, false);
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
