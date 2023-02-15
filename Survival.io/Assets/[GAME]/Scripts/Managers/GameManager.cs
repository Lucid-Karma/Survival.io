using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(()=> Time.timeScale = 1f);
    }
    void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(()=> Time.timeScale = 1f);
    }
    void Awake()
    {
        //Time.timeScale = 0f;
        EventManager.OnGameStart.Invoke();
    }
}
