using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTrying : MonoBehaviour
{
    [SerializeField] private GameObject stackParent, refObject;
    private float distanceBetweenObjects;

    public void CollectStackObject(GameObject brick)
    {

        distanceBetweenObjects = refObject.transform.localScale.y;

        brick.transform.parent = stackParent.transform;
        Vector3 desiredPos = refObject.transform.localPosition;
        desiredPos.y += distanceBetweenObjects;     //problematic.
        Debug.Log("SELAMUN ALEYKUM");

        brick.transform.localRotation = Quaternion.identity;
        brick.transform.localPosition = desiredPos;

        refObject.transform.position = brick.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            CollectStackObject(other.gameObject);
        }
    }
}
