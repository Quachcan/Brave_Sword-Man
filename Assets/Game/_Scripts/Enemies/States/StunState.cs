using System.Collections;
using System.Collections.Generic;
using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Cores.CoreComponents;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

public class StunState : State
{
    protected StunStateConfig StateConfig;
    
    protected Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
    private Movement movement;
        
    protected CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
    private CollisionSenses collisionSenses;
    

    protected bool IsStunTimeOver;
    protected bool IsGrounded;
    protected bool IsMovementStopped;
    protected bool PerformCloseRangeAction;
    protected bool IsPlayerInMinAgroRange;

    public StunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, StunStateConfig stateConfig) : base(entity, stateMachine, animBoolName)
    {
        this.StateConfig = stateConfig;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = CollisionSenses.Ground;
        PerformCloseRangeAction = Entity.CheckPlayerInCloseRangeAction();
        IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        IsStunTimeOver = false;
        IsMovementStopped = false;
        Movement?.SetVelocity(StateConfig.stunKnockbackSpeed, StateConfig.stunKnockbackAngle, Entity.LastDamageDirection);
        
    }

    public override void Exit()
    {
        base.Exit();
        Entity.ResetStunResistance();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= StartTime + StateConfig.stunTime)
        {
            IsStunTimeOver = true;
        }

        if(IsGrounded && Time.time >= StartTime + StateConfig.stunKnockbackTime && !IsMovementStopped)
        {
            IsMovementStopped = true;
            Movement?.SetVelocityX(0f);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
