using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInput : MonoBehaviour
{
    private WateringTask task;

    private void Start()
    {
        task = GetComponentInParent<WateringTask>();
    }

    // Reading Collision with Plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        task.OnT(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        task.OnTE(collision);
    }
}
