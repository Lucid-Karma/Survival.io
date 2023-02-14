using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITriggerController : MonoBehaviour
{
    [SerializeField] private Image filledArea;
    [SerializeField] private Animator animator;

    private GameObject playerObject;

    private bool fillAreaBool;



    void Start()
    {
        filledArea.fillAmount = 0;
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (fillAreaBool == true)
        {
            filledArea.fillAmount += 0.015f;
        }
        else if (fillAreaBool == false && filledArea.fillAmount > 0)
        {
            filledArea.fillAmount -= 0.02f;
        }

        if (filledArea.fillAmount == 1)
        {
            animator.SetBool("UIOpen",true);
            animator.SetBool("UIClose", false);
        }
        else
        {
            animator.SetBool("UIClose", true);
            animator.SetBool("UIOpen", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            fillAreaBool = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerObject) 
        {
            fillAreaBool = false;
            // filledArea.fillAmount = 0;
        }
    }
}
