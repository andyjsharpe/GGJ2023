using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Time.deltaTime * 80.0f) + transform.GetComponent<RectTransform>().anchoredPosition;
    }
}
