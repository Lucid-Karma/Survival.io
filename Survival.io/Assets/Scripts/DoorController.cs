using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class DoorController : MonoBehaviour
{
    public static DoorController instance;
    [SerializeField] private Collider playerCollider;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveUp();
            playerCollider.isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moveDown();
            playerCollider.isTrigger = false;
        }
    }

    public void moveUp()
    {
        transform.parent.DOLocalMoveY(4.3f, .5f).SetEase(Ease.OutQuad);
        Debug.Log("Move up");
    }
    public void moveDown()
    {
        transform.parent.DOLocalMoveY(1.4f, .5f).SetEase(Ease.InQuad);
        Debug.Log("Move down");
    }
}
