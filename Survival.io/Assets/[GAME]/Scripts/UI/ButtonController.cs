using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animator transitionPanel; 
    [SerializeField] private Animator ClosePanel;

    public void TryAgainScene()
    {
        transitionPanel.SetBool("TransitionStart", true);

        StartCoroutine(WaitTryAgain());
    }
    public void GoToScene(int sceneID) 
    {
        transitionPanel.SetBool("TransitionStart", true);

        StartCoroutine(WaitGoToScene(sceneID));
    }

    IEnumerator WaitTryAgain()
    {
        ClosePanelMethod();

        yield return new WaitForSeconds(1.5f); 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator WaitGoToScene(int sceneID)
    {
        ClosePanelMethod();

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(sceneID);
    }

    public void ClosePanelMethod()
    {
        ClosePanel.SetBool("UIClose", true);
        ClosePanel.SetBool("UIOpen", false);
    }
}
