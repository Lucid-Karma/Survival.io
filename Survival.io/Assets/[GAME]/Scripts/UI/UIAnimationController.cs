using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimationController : MonoBehaviour
{
    public static UIAnimationController instance;

    [SerializeField] private Animator animator;

    private GameObject playerObject;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            PanelOpen();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerObject) 
        {
            PanelClose();
        }
    }

    public void PanelOpen()
    {
        animator.SetBool("UIOpen", true);
        animator.SetBool("UIClose", false);
    }

    public void PanelClose()
    {
        animator.SetBool("UIClose", true);
        animator.SetBool("UIOpen", false);
    }
}
