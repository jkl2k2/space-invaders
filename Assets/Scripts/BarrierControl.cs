using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierControl : MonoBehaviour
{
    private int numHits;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (++numHits == 1) gameObject.SetActive(false);
    }
}
