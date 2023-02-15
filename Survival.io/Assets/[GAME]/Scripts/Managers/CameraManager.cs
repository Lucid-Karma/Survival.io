using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<GameObject> Cameras = new List<GameObject>();   // vcam1 is the first element.

    void OnEnable()
    {
        EventManager.OnGameStart.AddListener(ShowCloser);
        EventManager.OnLevelStart.AddListener(ShowFarAway);
    }
    void OnDisable()
    {
        EventManager.OnGameStart.RemoveListener(ShowCloser);
        EventManager.OnLevelStart.RemoveListener(ShowFarAway);
    }

    public void ShowCloser()
    {
        Cameras[0].SetActive(true);
        Cameras[1].SetActive(false);
    }

    public void ShowFarAway()
    {
        Cameras[0].SetActive(false);
        Cameras[1].SetActive(true);
    }
}
