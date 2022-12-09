using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override void EnterState(EnemyController fsm)
    {
        fsm.enemyAnimator.SetBool("isAttack",true);
    }

    public override void UpdateState(EnemyController fsm)
    {
        ExitState(fsm);
    }

    public override void ExitState(EnemyController fsm)
    {
        fsm.SwitchState(fsm.movementState);
    }
}
