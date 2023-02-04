using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterME : MonoBehaviour
{
    // Variables
    [SerializeField] float watered = 0.0f;
    public bool watering = false;
    bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (watering)
        {
            // TODO: Watering Animation Trigger

            if (watered < WateringTask.WATERING_LIMIT)
            {
                watered += Time.deltaTime * WateringTask.WATERING_RATE;
            } else
            {
                if (!complete)
                {
                    // Change status to complete is true & Update WATERED_COUNT
                    complete = true;
                    WateringTask.WATERED_COUNT++;

                    // Temporarily, change sprite tint
                    SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                    renderer.color = Color.yellow;
                }
            }
        }
        
    }
}
