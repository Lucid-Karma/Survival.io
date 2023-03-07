using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InIdleState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("in idle");
        fsm.SetBool(true);
    }

    public override void UpdateState(PlayerController fsm)
    {
        if (fsm.executingState == ExecutingState.INIDLE)
        {
            fsm.animator.SetBool("isOutIdle", false);
            fsm.animator.SetBool("isOutRunning", false);
            fsm.animator.SetBool("isInRunning", false);
            fsm.animator.SetBool("isInIdle", true);
            fsm.animator.SetBool("isIdleReloading", false);
            fsm.animator.SetBool("isRunningReload", false);
            fsm.animator.SetBool("isDead", false);
        }
        else 
            ExitState(fsm);
    }

    public override void ExitState(PlayerController fsm)
    {
        if(fsm.executingState == ExecutingState.INRUN)
        {
            fsm.SwitchState(fsm.inRunningState);
        }
        else if(fsm.executingState == ExecutingState.OUTRUN)
        {
            fsm.SwitchState(fsm.outRunningState);
        }
    }
}
