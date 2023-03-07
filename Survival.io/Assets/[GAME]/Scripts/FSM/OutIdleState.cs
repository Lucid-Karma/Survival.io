using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutIdleState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("out idle");
        fsm.SetBool(false);
    }

    public override void UpdateState(PlayerController fsm)
    {
        if (fsm.executingState == ExecutingState.OUTIDLE)
        {
            fsm.animator.SetBool("isOutIdle", true);
            fsm.animator.SetBool("isOutRunning", false);
            fsm.animator.SetBool("isInRunning", false);
            fsm.animator.SetBool("isInIdle", false);
            fsm.animator.SetBool("isIdleReloading", false);
            fsm.animator.SetBool("isRunningReload", false);
            fsm.animator.SetBool("isDead", false);

            //fsm.FindEnemy();
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
