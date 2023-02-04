using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent interactEvent;
    private taskManager taskManager;
    [SerializeField]
    private taskManager.TaskOptions task;

    private void Start()
    {
        taskManager = FindObjectOfType<taskManager>();
    }

    public bool isDoable()
    {
        if (task != taskManager.TaskOptions.None)
        {
            if (taskManager.isTaskDone(task))
            {
                return false; //do not allow task to be done again if already completed
            }
        }
        return true;
    }


    public void interact()
    {
        if (!isDoable())
        {
            return;
        }
        
        if (interactEvent != null) {
            interactEvent.Invoke(); 
        }
    }
}
