using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertilizingTask : MonoBehaviour
{
    // Variables & Fields
    public static int FERTILIZED_COUNT = 0;
    public static float FERTILIZED_LIMIT = 100;
    public static float FERTILIZING_RATE = 2;

    [SerializeField] Vector2 START_POS;

    // Private Variables
    private Vector3 screenPoint;
    private Vector3 offset;
    [SerializeField] int plantCount;

    GameObject lockPlant;

    // Start is called before the first frame update
    void Start()
    {
        // Set Position of Watering Can
        ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (plantCount == FERTILIZED_COUNT)
        {
            Debug.Log("TASK COMPLETE");
        }
    }

    // Reading Collision with Plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Plant")
        {
            FertilizerME fertilizeStatus = other.GetComponent<FertilizerME>();
            lockPlant = other;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Plant")
        {
            FertilizerME fertilizeStatus = other.GetComponent<FertilizerME>();
            lockPlant = null;
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
        if (lockPlant != null)
        {
            //TODO: Switch to Animation of bag
            this.transform.position = lockPlant.transform.position;
            lockPlant.GetComponent<FertilizerME>().fertilizing = true;
        } else
        {
            ResetPosition();
        }

        // Reset position once animation ends;
        
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
