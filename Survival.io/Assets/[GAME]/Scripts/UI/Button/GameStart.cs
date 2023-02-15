using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //public GameObject startButton;

    public void StartLevelButton()
    {
        // EventManager.OnLevelStart.Invoke();
        // startButton.SetActive(false);

        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
