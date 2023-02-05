using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskActivator : MonoBehaviour
{
    [SerializeField]
    private taskManager.TaskOptions task;
    [SerializeField]
    private UnityEvent activatetEvent;

    // Start is called before the first frame update
    void Start()
    {
        taskManager manager = FindObjectOfType<taskManager>();
        if (manager.isTaskDone(task))
        {
            activatetEvent.Invoke();
        }
    }

}
