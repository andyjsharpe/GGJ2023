using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringTask : MonoBehaviour
{
    // Variables & Fields
    public static float WATERING_RATE = 20f;
    public static float WATERING_LIMIT = 100f;
    public static int WATERED_COUNT = 0;

    [SerializeField] Vector2 START_POS;

    // Private Variables
    private Vector3 screenPoint;
    private Vector3 offset;
    [SerializeField] int plantCount; 

    // Start is called before the first frame update
    void Start()
    {
        // Set Position of Watering Can
        ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(plantCount == WATERED_COUNT)
        {
            Debug.Log("TASK COMPLETE");
        }
    }

    // Reading Collision with Plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag =="Plant")
        {
            WaterME waterStatus = other.GetComponent<WaterME>();
            waterStatus.watering = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Plant")
        {
            WaterME waterStatus = other.GetComponent<WaterME>();
            waterStatus.watering = false;
        }
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
    void OnMouseUp()
    {
        ResetPosition();
    }

    private void ResetPosition()
    {
        Vector3 pos = new Vector3();
        pos.x = START_POS.x;
        pos.y = START_POS.y;
        pos.z = transform.position.z;
        this.transform.position = pos;
    }
}
