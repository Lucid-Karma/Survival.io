using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> uiElements = new List<GameObject>();

    void OnEnable()
    {
        EventManager.OnGameStart.AddListener(HideElement);
        EventManager.OnLevelStart.AddListener(ShowElement);
    }
    void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(HideElement);
        EventManager.OnLevelStart.RemoveListener(ShowElement);
    }

    public void ShowElement()
    {
        foreach (var element in uiElements)
        {
            element.SetActive(true);
        }
    }

    public void HideElement()
    {
        foreach (var element in uiElements)
        {
            element.SetActive(false);
        }
    }
}
