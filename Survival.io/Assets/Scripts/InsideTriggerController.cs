using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideTriggerController : MonoBehaviour
{
    private GameObject playerGameobject;
    [SerializeField] private Collider playerCollider;
    
    private void Start()
    {
        playerGameobject = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerGameobject)
        {
            Debug.Log("Player içeride.");
            playerCollider.isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerGameobject)
        {
            playerCollider.isTrigger = false;
        }
    }
}
