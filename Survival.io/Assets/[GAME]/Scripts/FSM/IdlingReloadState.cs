using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingReloadState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("Reload Idle");
        fsm.SetBool(false);
    }

    public override void UpdateState(PlayerController fsm)
    {
        if (fsm.executingState == ExecutingState.IDLERELOAD)
        {
            fsm.animator.SetBool("isOutIdle", false);
        fsm.animator.SetBool("isOutRunning", false);
        fsm.animator.SetBool("isInRunning", false);
        fsm.animator.SetBool("isInIdle", false);
        fsm.animator.SetBool("isIdleReloading", true);
        fsm.animator.SetBool("isRunningReload", false);
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
        else if(fsm.executingState == ExecutingState.RUNRELOAD)
        {
            fsm.SwitchState(fsm.runningReloadState);
        }
        else if(fsm.executingState == ExecutingState.OUTIDLE)
        {
            fsm.SwitchState(fsm.outIdleState);
        } 
    }
}
