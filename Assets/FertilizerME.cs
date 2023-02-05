using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizerME : MonoBehaviour
{
    // Variables
    [SerializeField] float fertilized = 0.0f;
    public bool fertilizing = false;
    bool complete = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fertilizing)
        {
            // TODO: Watering Animation Trigger

            /*if (fertilized < WateringTask.WATERING_LIMIT)
            {
                fertilized += Time.deltaTime * FertilizingTask;
            }
            else
            {
                if (!complete)
                {
                    // Change status to complete is true & Update WATERED_COUNT
                    complete = true;
                    WateringTask.WATERED_COUNT++;

                    // Temporarily, change sprite tint
                    SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                    renderer.color = Color.gray;
                }
            }*/
        }

    }
}
