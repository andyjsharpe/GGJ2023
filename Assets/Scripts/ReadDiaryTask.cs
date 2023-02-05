using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadDiaryTask : MonoBehaviour
{
    TaskCompleter taskCompleter;
    
    private void Start()
    {
        taskCompleter = GetComponent<TaskCompleter>();
    }

    public void doRead()
    {
        taskCompleter.completeTask(taskManager.TaskOptions.CheckRoom); //This completes the "CheckRoom" task
    }
}
