using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFloat : MonoBehaviour
{
    [SerializeField] private float height;
    [SerializeField] private float speed;
    private float counter;
    private Vector3 ogPos;

    private void Start()
    {
        ogPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        counter+= Time.deltaTime;
        float completion = (1 + Mathf.Sin(speed * counter))/2;
        transform.position = ogPos + transform.up * height * completion;
    }
}
