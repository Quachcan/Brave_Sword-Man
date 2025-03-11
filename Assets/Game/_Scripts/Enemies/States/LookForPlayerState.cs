using System.Collections;
using System.Collections.Generic;
using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Enemies.State_Machine;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

public class LookForPlayerState : State
{
    protected LookForPlayerConfig StateConfig;

    protected Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
    private Movement movement;
        
    protected CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
    private CollisionSenses collisionSenses;
    
    protected bool TurnImmediately;
    protected bool IsPlayerInMinAgroRange;
    protected bool IsPlayerInMaxAgroRange;
    protected bool IsAllTurnsDone;
    protected bool IsAllTurnsTimeDone;

    protected float LastTurnTime;

    protected int AmountOfTurnsDone;

    public LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, LookForPlayerConfig stateConfig) : base(entity, stateMachine, animBoolName)
    {
        this.StateConfig = stateConfig;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
        IsPlayerInMaxAgroRange = Entity.CheckPlayerInMaxAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        IsAllTurnsDone = false;
        IsAllTurnsTimeDone = false;

        LastTurnTime = StartTime;
        AmountOfTurnsDone = 0;

        Movement?.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocityX(0f);

        if (TurnImmediately)
        {
            Movement?.Flip();
            LastTurnTime = Time.time;
            AmountOfTurnsDone++;
            TurnImmediately = false;
        }
        else if(Time.time >= LastTurnTime + StateConfig.timeBetweenTurns && !IsAllTurnsDone)
        {
            Movement?.Flip();
            LastTurnTime = Time.time;
            AmountOfTurnsDone++;
        }

        if(AmountOfTurnsDone >= StateConfig.amountOfTurns)
        {
            IsAllTurnsDone = true;
        }

        if(Time.time >= LastTurnTime + StateConfig.timeBetweenTurns && IsAllTurnsDone)
        {
            IsAllTurnsTimeDone = true;
        }
    }
    

    public void SetTurnImmediately(bool flip)
    {
        TurnImmediately = flip;
    }
}
