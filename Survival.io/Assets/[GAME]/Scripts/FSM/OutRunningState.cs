using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutRunningState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("out running");
        fsm.SetBool(false);
    }

    public override void UpdateState(PlayerController fsm)
    {
            if (fsm.executingState != ExecutingState.OUTRUN)
            {
                ExitState(fsm);
            }
            else
            {
                fsm.animator.SetBool("isOutRunning", true);
                fsm.animator.SetBool("isOutIdle", false);
                fsm.animator.SetBool("isInRunning", false);
                fsm.animator.SetBool("isInIdle", false);
                fsm.animator.SetBool("isIdleReloading", false);
                fsm.animator.SetBool("isRunningReload", false);
                fsm.animator.SetBool("isDead", false);

                //fsm.FindEnemy();
            }
    }

    public override void ExitState(PlayerController fsm)
    {
        if(fsm.executingState == ExecutingState.INRUN) 
        {
            fsm.SwitchState(fsm.inRunningState);
        }
        else if(fsm.executingState == ExecutingState.OUTIDLE)
        {
            fsm.SwitchState(fsm.outIdleState);
        } 
        else if(fsm.executingState == ExecutingState.RUNRELOAD)
        {
            fsm.SwitchState(fsm.runningReloadState);
        }
        else if(fsm.executingState == ExecutingState.IDLERELOAD)
        {
            fsm.SwitchState(fsm.idlingReloadState);
        }
        else if(fsm.executingState == ExecutingState.DEAD)
        {
            fsm.SwitchState(fsm.deathState);
        } 
    }
}
