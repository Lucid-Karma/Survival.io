using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    private Transform followCamera;
    private void Start()
    {
        followCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    void Update()
    {
        Vector3 targetPosition = new Vector3(followCamera.position.x, this.transform.position.y, followCamera.position.z);
        this.transform.LookAt(targetPosition);
    }
}
