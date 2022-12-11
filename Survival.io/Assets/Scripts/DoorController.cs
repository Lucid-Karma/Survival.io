using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class DoorController : MonoBehaviour
{
    public static DoorController instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveUp();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveDown();
        }
    }

    public void moveUp()
    {
        transform.DOLocalMoveY(4.3f, .5f).SetEase(Ease.OutQuad);
        Debug.Log("Move up");
    }
    public void moveDown()
    {
        transform.DOLocalMoveY(1.4f, .5f).SetEase(Ease.InQuad);
        Debug.Log("Move down");
    }
}
