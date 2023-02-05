using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveME : MonoBehaviour
{
    // Variables
    GameObject bag; 
    public Vector2 START_POS;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check it isn't another plant
        if (collision.gameObject.tag != "Plant")
            bag = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check it isn't another plant
        if (collision.gameObject.tag != "Plant")
            bag = null;
    }

   
    void OnMouseUp()
    {
        if (bag != null)
        {
            RemovingTask.REMOVING_COUNT++;
            Destroy(this.gameObject);
        }
        else
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

    // Code to Allow Draggable
    private Vector3 screenPoint;
    private Vector3 offset;

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


}
