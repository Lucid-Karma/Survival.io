using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadCanvas : MonoBehaviour
{
    [SerializeField] private Image reloadImage;
    [SerializeField] private GameObject reloadImageObject;    

    private Camera cam;

    private bool isReloading;

    private void Awake()
    {
        reloadImageObject.SetActive(false);
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }

    private void FixedUpdate()
    {
        if (BaseBulletSpawner.isReloading && reloadImage.fillAmount < 1)
        {
            Debug.Log("RELOAD TIME");
            reloadImageObject.SetActive(true);

            reloadImage.fillAmount += 0.011f;
        }
        else
        {
            reloadImageObject.SetActive(false);
            reloadImage.fillAmount = 0;
        }
    }
}
