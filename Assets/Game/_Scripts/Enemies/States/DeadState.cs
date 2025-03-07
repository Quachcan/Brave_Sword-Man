using System.Collections;
using System.Collections.Generic;
using Game._Scripts.Enemies.State_Machine;
using UnityEngine;

public class DeadState : State
{
    protected DeadStateConfig StateConfig;

    public DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, DeadStateConfig stateConfig) : base(entity, stateMachine, animBoolName)
    {
        this.StateConfig = stateConfig;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        GameObject.Instantiate(StateConfig.deathBloodParticle, Entity.transform.position, StateConfig.deathBloodParticle.transform.rotation);
        GameObject.Instantiate(StateConfig.deathChunkParticle, Entity.transform.position, StateConfig.deathChunkParticle.transform.rotation);

        Entity.gameObject.SetActive(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
