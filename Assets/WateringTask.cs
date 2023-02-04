using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringTask : MonoBehaviour
{
    // Variables & Fields
    [SerializeField] Vector2 START_POS;

    // Private Variables
    private Vector3 screenPoint;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Set Position of Watering Can
        ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Debug.Log("Mouse Drag");
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
    void OnMouseUp()
    {
        Debug.Log("Mouse Up");
    }

    private void ResetPosition()
    {
        Vector3 pos = new Vector3();
        pos.x = START_POS.x;
        pos.y = START_POS.y;
        pos.z = transform.localPosition.z;
        this.transform.localPosition = pos;
    }
}
