using System.Collections;
using System.Collections.Generic;
using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Cores.CoreComponents;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

public class DodgeState : State
{
    protected DodgeStateConfig StateConfig;
    
    protected Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
    private Movement movement;
        
    protected CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
    private CollisionSenses collisionSenses;

    protected bool PerformCloseRangeAction;
    protected bool IsPlayerInMaxAgroRange;
    protected bool IsGrounded;
    protected bool IsDodgeOver;

    public DodgeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DodgeStateConfig stateConfig) : base(entity, stateMachine, animBoolName)
    {
        this.StateConfig = stateConfig;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        PerformCloseRangeAction = Entity.CheckPlayerInCloseRangeAction();
        IsPlayerInMaxAgroRange = Entity.CheckPlayerInMaxAgroRange();
        IsGrounded = CollisionSenses.Ground;
    }

    public override void Enter()
    {
        base.Enter();

        IsDodgeOver = false;

        Movement?.SetVelocity(StateConfig.dodgeSpeed, StateConfig.dodgeAngle, -Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= StartTime + StateConfig.dodgeTime && IsGrounded)
        {
            IsDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
