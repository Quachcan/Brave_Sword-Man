using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Enemies.State_Machine;
using UnityEngine;

public class DodgeState : State
{
    protected D_DodgeState stateData;

    protected bool PerformCloseRangeAction;
    protected bool IsPlayerInMaxAgroRange;
    protected bool IsGrounded;
    protected bool IsDodgeOver;

    public DodgeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DodgeState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        PerformCloseRangeAction = Entity.CheckPlayerInCloseRangeAction();
        IsPlayerInMaxAgroRange = Entity.CheckPlayerInMaxAgroRange();
        IsGrounded = Core.CollisionSenses.Ground;
    }

    public override void Enter()
    {
        base.Enter();

        IsDodgeOver = false;

        Core.Movement.SetVelocity(stateData.dodgeSpeed, stateData.dodgeAngle, -Core.Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= StartTime + stateData.dodgeTime && IsGrounded)
        {
            IsDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
