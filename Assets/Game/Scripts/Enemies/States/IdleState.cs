using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Enemies.State_Machine;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState StateData;

    protected bool FlipAfterIdle;
    protected bool IsIdleTimeOver;
    protected bool IsPlayerInMinAgroRange;

    protected float IdleTime;

    public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.StateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        //core.Movement.SetVelocityX(0f);
        IsIdleTimeOver = false;        
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if (FlipAfterIdle)
        {
            Core.Movement.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Core.Movement.SetVelocityX(0f);

        if (Time.time >= StartTime + IdleTime)
        {
            IsIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();        
    }

    public void SetFlipAfterIdle(bool flip)
    {
        FlipAfterIdle = flip;
    }

    private void SetRandomIdleTime()
    {
        IdleTime = Random.Range(StateData.minIdleTime, StateData.maxIdleTime);
    }
}
