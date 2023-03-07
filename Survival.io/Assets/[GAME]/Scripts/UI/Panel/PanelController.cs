using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public List<GameObject> panelList = new List<GameObject>();

    void OnEnable()
    {
        EventManager.OnLevelEnd.AddListener(ControlPanels);
    }
    void OnDisable()
    {
        EventManager.OnLevelEnd.RemoveListener(ControlPanels);
    }

    void ControlPanels()
    {
        foreach (var panel in panelList)
        {
            panel.SetActive(false);
        }
    }
}
