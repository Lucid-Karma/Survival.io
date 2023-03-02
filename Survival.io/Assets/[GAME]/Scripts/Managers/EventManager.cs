using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent OnCharacterOutRunning = new UnityEvent();
    public static UnityEvent OnCharacterInRunning = new UnityEvent();
    public static UnityEvent OnCharacterOutIdle = new UnityEvent();
    public static UnityEvent OnCharacterInIdle = new UnityEvent();
    public static UnityEvent OnEnemyDying = new UnityEvent();


    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnLevelStart = new UnityEvent();

    public static UnityEvent OnSpeedIncrease = new UnityEvent();
    public static UnityEvent OnAmmoIncrease = new UnityEvent();
    public static UnityEvent OnDamageIncrease = new UnityEvent();


    public static UnityEvent OnGunUpdate = new UnityEvent();
}
