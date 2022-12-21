using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideTriggerController : MonoBehaviour
{
    private GameObject playerGameobject;
    
    private void Start()
    {
        playerGameobject = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerGameobject)
        {
            Debug.Log("Player i�eride.");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerGameobject)
        {
            Debug.Log("Player d��ar�da.");
            
        }
    }
}
