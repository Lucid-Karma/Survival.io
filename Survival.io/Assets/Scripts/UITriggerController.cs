using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITriggerController : MonoBehaviour
{
    [SerializeField] private Image filledArea;

    private bool fillAreaBool;

    void Start()
    {
        filledArea.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fillAreaBool == true)
        {
            filledArea.fillAmount += 0.015f;
        }
        else if (fillAreaBool == false && filledArea.fillAmount > 0)
        {
            filledArea.fillAmount -= 0.02f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fillAreaBool = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fillAreaBool = false;
            // filledArea.fillAmount = 0;
        }
    }
}
