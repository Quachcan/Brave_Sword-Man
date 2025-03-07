using System.Collections;
using System.Collections.Generic;
using Game._Scripts.Enemies.States;
using Game.Scripts.Enemies.States;
using UnityEngine;

public class AnimationToStatemachine : MonoBehaviour
{
    public AttackState attackState;

    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
