using System.Collections;
using System.Collections.Generic;
using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States;
using Game.Scripts.Enemies.States;
using Game.Scripts.Enemies.States.Data;
using UnityEngine;

public class RangedAttackState : AttackState
{
    protected RangedAttackStateConfig StateConfig;

    protected GameObject Projectile;
    //protected Projectile projectileScript;

    public RangedAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, RangedAttackStateConfig stateConfig) : base(entity, stateMachine, animBoolName, attackPosition)
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        // projectile = GameObject.Instantiate(stateData.projectile, attackPosition.position, attackPosition.rotation);
        // projectileScript = projectile.GetComponent<Projectile>();
        // projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage);
    }
}
