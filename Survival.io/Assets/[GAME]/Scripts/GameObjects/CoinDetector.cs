using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.GetComponent<ICollectable>();

        if (collectable != null)
            collectable.Collect();
    }
}
