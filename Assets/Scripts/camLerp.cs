using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camLerp : MonoBehaviour
{
    [SerializeField] private float Duration;
    [SerializeField] private Transform target;
    [SerializeField] private Light light1;
    private float intensity1;
    [SerializeField] private Light light2;
    private float intensity2;
    private Vector3 oldP;
    private Quaternion oldR;
    private float counter;
    [SerializeField] private float maxCutoff;
    [SerializeField] private float maxDistortion;
    private AudioHighPassFilter filter;
    private AudioDistortionFilter filter2;

    private void Start()
    {
        filter = FindObjectOfType<AudioHighPassFilter>();
        filter2 = FindObjectOfType<AudioDistortionFilter>();
        oldP = transform.position;
        oldR = transform.rotation;
        intensity1 = light1.intensity;
        intensity2 = light2.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        transform.position = Vector3.Lerp(oldP, target.position, counter / Duration);
        transform.rotation = Quaternion.Lerp(oldR, target.rotation, counter / Duration);
        light1.intensity = -intensity1 * Mathf.Sin(func(counter - 0.5f, Duration));
        light2.intensity = -intensity2 * Mathf.Sin(func(counter - 0.5f, Duration) - counter);
        if (filter != null)
        {
            filter.cutoffFrequency = Mathf.Lerp(10, maxCutoff, counter / Duration);
        }
        if (filter2 != null)
        {
            filter2.distortionLevel = Mathf.Lerp(0, maxDistortion, counter / Duration);
        }
        

        if (counter > Duration)
        {
            if (filter != null) 
            {
                filter.cutoffFrequency = 10;
            }
            if (filter2 != null)
            {
                filter2.distortionLevel = 0;
            }
        }
    }

    private float func(float a, float b)
    {
        return (a+b)/(a-b);
    }
}
