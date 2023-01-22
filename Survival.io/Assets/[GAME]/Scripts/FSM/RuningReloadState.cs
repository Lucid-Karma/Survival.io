using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuningReloadState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("Reload Running");
        fsm.SetBool(false);
    }

    public override void UpdateState(PlayerController fsm)
    {
        if (fsm.executingState == ExecutingState.RUNRELOAD)
        {
            fsm.animator.SetBool("isOutIdle", false);
            fsm.animator.SetBool("isOutRunning", false);
            fsm.animator.SetBool("isInRunning", false);
            fsm.animator.SetBool("isInIdle", false);
            fsm.animator.SetBool("isIdleReloading", false);
            fsm.animator.SetBool("isRunningReload", true);
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
        else if(fsm.executingState == ExecutingState.IDLERELOAD)
        {
            fsm.SwitchState(fsm.idlingReloadState);
        }
        else if(fsm.executingState == ExecutingState.INRUN)
        {
            fsm.SwitchState(fsm.inRunningState);
        }
    }
}
