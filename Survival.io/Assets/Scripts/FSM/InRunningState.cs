using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRunningState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("in run");
    }

    public override void UpdateState(PlayerController fsm)
    {
        if (fsm.executingState == ExecutingState.INRUN)
        {
            fsm.animator.SetBool("isOutIdle", false);
        fsm.animator.SetBool("isOutRunning", false);
        fsm.animator.SetBool("isInRunning", true);
        fsm.animator.SetBool("isInIdle", false);
        }
        else
            ExitState(fsm);
    }

    public override void ExitState(PlayerController fsm)
    {
        if(fsm.executingState == ExecutingState.INIDLE)
        {
            fsm.SwitchState(fsm.inIdleState);
        }
        else if(fsm.executingState == ExecutingState.OUTRUN)
        {
            fsm.SwitchState(fsm.outRunningState);
        }
    }
}
