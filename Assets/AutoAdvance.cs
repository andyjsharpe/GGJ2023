using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoAdvance : MonoBehaviour
{
    private float counter;
    [SerializeField] private float duration;

    private void Update()
    {
        counter += Time.deltaTime;
        if (counter > duration)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("toReturnToS"));
        }
    }
}