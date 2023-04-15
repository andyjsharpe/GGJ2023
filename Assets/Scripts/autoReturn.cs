using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class autoReturn : MonoBehaviour
{
    private float counter;
    [SerializeField] private float duration;

    private void Update()
    {
        counter+= Time.deltaTime;
        if (counter > duration)
        {
            AudioHighPassFilter filter = FindObjectOfType<AudioHighPassFilter>();
            AudioDistortionFilter filter2 = FindObjectOfType<AudioDistortionFilter>();
            filter.cutoffFrequency = 10;
            filter2.distortionLevel = 0;
            SceneManager.LoadScene(PlayerPrefs.GetInt("toReturnTo"));
        }
    }
}
