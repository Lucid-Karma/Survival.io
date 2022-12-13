using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStates 
{
    public abstract void EnterState(PlayerController fsm);
    public abstract void UpdateState(PlayerController fsm);
    public abstract void ExitState(PlayerController fsm);
}
