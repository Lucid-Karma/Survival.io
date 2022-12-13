using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class DoorController : MonoBehaviour
{
    public static DoorController instance;
    [SerializeField] private Collider playerCollider;
    [SerializeField] private GameObject doorLeft, doorRight;

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
        doorLeft.transform.DOLocalMoveZ(-1.4f, .5f).SetEase(Ease.OutQuad);
        doorRight.transform.DOLocalMoveZ(1.4f, .5f).SetEase(Ease.OutQuad);
    }
    public void moveDown()
    {
        doorLeft.transform.DOLocalMoveZ(-0.5f, .5f).SetEase(Ease.OutQuad);
        doorRight.transform.DOLocalMoveZ(0.5f, .5f).SetEase(Ease.OutQuad);
    }
}
