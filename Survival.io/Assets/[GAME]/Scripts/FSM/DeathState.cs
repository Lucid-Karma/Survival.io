using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("death");
        fsm.SetBool(false);
        EventManager.OnLevelEnd.Invoke();
    }

    public override void UpdateState(PlayerController fsm)
    {
            if (fsm.executingState != ExecutingState.DEAD)
            {
                ExitState(fsm);
            }
            else
            {
                fsm.animator.SetBool("isOutRunning", false);
                fsm.animator.SetBool("isOutIdle", false);
                fsm.animator.SetBool("isInRunning", false);
                fsm.animator.SetBool("isInIdle", false);
                fsm.animator.SetBool("isIdleReloading", false);
                fsm.animator.SetBool("isRunningReload", false);
                fsm.animator.SetBool("isDead", true);
            }
    }

    public override void ExitState(PlayerController fsm)
    {
        return;
        // if(fsm.executingState == ExecutingState.INRUN) 
        // {
        //     fsm.SwitchState(fsm.inRunningState);
        // }
        // else if(fsm.executingState == ExecutingState.OUTIDLE)
        // {
        //     fsm.SwitchState(fsm.outIdleState);
        // } 
        // else if(fsm.executingState == ExecutingState.RUNRELOAD)
        // {
        //     fsm.SwitchState(fsm.runningReloadState);
        // }
        // else if(fsm.executingState == ExecutingState.IDLERELOAD)
        // {
        //     fsm.SwitchState(fsm.idlingReloadState);
        // }
    }
}
