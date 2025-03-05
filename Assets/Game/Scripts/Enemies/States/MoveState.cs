using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Enemies.State_Machine;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool IsDetectingWall;
    protected bool IsDetectingLedge;
    protected bool IsPlayerInMinAgroRange;

    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsDetectingLedge = Core.CollisionSenses.LedgeVertical;
        IsDetectingWall = Core.CollisionSenses.WallFront;
        IsPlayerInMinAgroRange = Entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();
        //core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.FacingDirection);
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //core.Movement.SetVelocityX(stateData.movementSpeed * core.Movement.FacingDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
