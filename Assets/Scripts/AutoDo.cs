using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AutoDo : MonoBehaviour
{
    private float counter;
    [SerializeField] private float duration;
    [SerializeField] private UnityEvent uevent;

    private void Update()
    {
        counter += Time.deltaTime;
        if (counter > duration)
        {
            uevent.Invoke();
        }
    }
}
