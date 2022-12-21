using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public float lerpValue;
    private GameObject playerGameObject;

    private void LateUpdate()
    {
        // Vector3 desPos = PlayerController.instance.gameObject.transform.position + offset;
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        Vector3 desPos = playerGameObject.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);
    }
}
