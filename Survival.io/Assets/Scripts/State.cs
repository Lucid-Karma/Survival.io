using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public abstract void EnterState(EnemyController fsm);
    public abstract void UpdateState(EnemyController fsm);
    public abstract void ExitState(EnemyController fsm);
}
