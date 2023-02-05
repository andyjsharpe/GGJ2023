using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizerME : MonoBehaviour
{
    // Variables
    [SerializeField] float fertilized = 0.0f;
    [SerializeField] Sprite unMixed;
    [SerializeField] Sprite Mixed;

    public bool fertilizing = false;
    bool complete = false;

    private Vector3 screenPoint;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (fertilizing)
        {

            if (!(fertilized < FertilizingTask.FERTILIZED_LIMIT))
            {
                if (!complete)
                {
                    // Change status to complete is true & Update WATERED_COUNT
                    complete = true;
                    FertilizingTask.FERTILIZED_COUNT++;

                    // Temporarily, change sprite tint
                    SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                    //renderer.color = Color.gray;
                    renderer.sprite = Mixed;
                }
            }
        }

    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (fertilizing)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            // Calculate difference in positions & update fertilization status of plant
            float magnitude = (curPosition - transform.position).magnitude;
            this.fertilized += magnitude * FertilizingTask.FERTILIZING_RATE;
        }

    }

    public void readyToMix()
    {
        SpriteRenderer temp = this.GetComponent<SpriteRenderer>();
        temp.sprite = unMixed;
        temp.color = Color.white;
    }
}
