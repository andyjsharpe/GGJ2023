using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadWarp : MonoBehaviour
{
    private taskManager taskManager;
    
    // Start is called before the first frame update
    void Start()
    {
        taskManager = FindObjectOfType<taskManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taskManager.isTaskDone(taskManager.TaskOptions.Read))
        {
            SceneManager.LoadScene(18);
        }
    }
}
