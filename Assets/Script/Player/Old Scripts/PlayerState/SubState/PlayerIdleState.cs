using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

        public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (xInput != 0)
            {
                stateMachine.ChangeState(player.moveState);
            }
            else if (yInput == -1)
            {
                stateMachine.ChangeState(player.crouchIdleState);
            }

        }

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }
}
