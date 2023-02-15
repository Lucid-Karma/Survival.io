using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    //public GameObject startButton;
    [SerializeField] private Animator animator;

    public void StartLevelButton()
    {
        // EventManager.OnLevelStart.Invoke();
        // startButton.SetActive(false);

        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        animator.SetBool("TransitionStart", true);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
