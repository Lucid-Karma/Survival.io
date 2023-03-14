using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isLevelEnd = false;
    void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(()=> Time.timeScale = 1f);
        EventManager.OnLevelEnd.AddListener(()=> isLevelEnd = true);

        //EventManager.OnSpeedIncrease.AddListener(()=> Debug.Log("MANAGER"));
        //EventManager.OnSpeedIncrease.AddListener(PistolSpeedIncrease);
    }
    void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(()=> Time.timeScale = 1f);
        EventManager.OnLevelEnd.RemoveListener(()=> isLevelEnd = true);

        //EventManager.OnSpeedIncrease.RemoveListener(()=> Debug.Log("MANAGER"));
        //EventManager.OnSpeedIncrease.RemoveListener(PistolSpeedIncrease);
    }
    void Awake()
    {
        instance = this;
        //Time.timeScale = 0f;
        EventManager.OnGameStart.Invoke();
    }

    // private void PistolSpeedIncrease()
    // {
    //     Debug.Log("MANAGER");
    // }
}
