using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private Animator ContinuePanel;
    [SerializeField] private Animator FailPanel;
    

    private bool continueBool = false, failBool = false;
    private void Awake()
    {
        instance = this;
        
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        if (continueBool)
        {
            continueBool = false;
            StartCoroutine(ContinuePanelWait());
        }
        else if (failBool)
        {
            failBool = false;
            StartCoroutine(FailPanelWait());
        }
    }
    public void ContinueBoolMethod()
    {
        continueBool = true;
    }
    public void FailBoolMethod()
    {
        failBool = true;
    }

    public void ContinuePanelSet()
    {
        ContinuePanel.SetBool("UIOpen", true);
        ContinuePanel.SetBool("UIClose", false);
    }

    public void FailPanelSet()
    {
        FailPanel.SetBool("UIOpen", true);
        FailPanel.SetBool("UIClose", false);
    }

    IEnumerator ContinuePanelWait()
    {
        yield return new WaitForSeconds(1f);
        ContinuePanelSet();
    }

    IEnumerator FailPanelWait()
    {
        yield return new WaitForSeconds(1f);
        FailPanelSet();
    }

}
