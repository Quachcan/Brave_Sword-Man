﻿using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Enemies.States;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected D_MeleeAttack StateData;    

    public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.StateData = stateData;
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

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(AttackPosition.position, StateData.attackRadius, StateData.whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            // IDamageable damageable = collider.GetComponent<IDamageable>();
            //
            // if(damageable != null)
            // {
            //     damageable.Damage(stateData.attackDamage);
            // }
            //
            // IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();
            //
            // if(knockbackable != null)
            // {
            //     knockbackable.Knockback(stateData.knockbackAngle, stateData.knockbackStrength, core.Movement.FacingDirection);
            // }
        }
    }
}
