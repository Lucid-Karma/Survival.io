using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class DoorController : MonoBehaviour
{
    // [SerializeField] private GameObject ParentDoorObject;

    private void OnEnable()
    {
        EventManager.doorOpening.AddListener(moveUp);
        EventManager.doorClosing.AddListener(moveDown);
    }

    private void OnDisable()
    {
        EventManager.doorOpening.RemoveListener(moveUp);
        EventManager.doorClosing.RemoveListener(moveDown);
    }

    private void moveUp()
    {
        transform.DOLocalMoveY(4.3f, .5f).SetEase(Ease.OutQuad);
    }
    private void moveDown()
    {
        transform.DOLocalMoveY(1.4f, .5f).SetEase(Ease.InQuad);
    }
}
