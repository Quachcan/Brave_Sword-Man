using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Enemies.State_Machine;
using UnityEngine;

public class LookForPlayerState : State
{
    protected D_LookForPlayer StateData;

    protected bool TurnImmediately;
    protected bool IsPlayerInMinAgroRange;
    protected bool IsAllTurnsDone;
    protected bool IsAllTurnsTimeDone;

    protected float LastTurnTime;

    protected int AmountOfTurnsDone;

    public LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData) : base(entity, stateMachine, animBoolName)
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

        IsAllTurnsDone = false;
        IsAllTurnsTimeDone = false;

        LastTurnTime = StartTime;
        AmountOfTurnsDone = 0;

        //core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Core.Movement.SetVelocityX(0f);

        if (TurnImmediately)
        {
            Core.Movement.Flip();
            LastTurnTime = Time.time;
            AmountOfTurnsDone++;
            TurnImmediately = false;
        }
        else if(Time.time >= LastTurnTime + StateData.timeBetweenTurns && !IsAllTurnsDone)
        {
            Core.Movement.Flip();
            LastTurnTime = Time.time;
            AmountOfTurnsDone++;
        }

        if(AmountOfTurnsDone >= StateData.amountOfTurns)
        {
            IsAllTurnsDone = true;
        }

        if(Time.time >= LastTurnTime + StateData.timeBetweenTurns && IsAllTurnsDone)
        {
            IsAllTurnsTimeDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetTurnImmediately(bool flip)
    {
        TurnImmediately = flip;
    }
}
