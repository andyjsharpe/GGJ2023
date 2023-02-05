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
    private taskManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<taskManager>();
        recalcTasks();
    }

    public void recalcTasks()
    {
        if (manager.isTaskDone(task))
        {
            activatetEvent.Invoke();
        }
    }

}
