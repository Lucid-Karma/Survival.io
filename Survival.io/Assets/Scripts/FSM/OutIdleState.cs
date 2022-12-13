using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutIdleState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("out idle");
    }

    public override void UpdateState(PlayerController fsm)
    {
        if (fsm.executingState == ExecutingState.OUTIDLE)
        {
            fsm.animator.SetBool("isOutIdle", true);
            fsm.animator.SetBool("isOutRunning", false);
            fsm.animator.SetBool("isInRunning", false);
            fsm.animator.SetBool("isInIdle", false);
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
