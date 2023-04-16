using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SocializingTask : MonoBehaviour
{
    private float messageCountdown;
    private bool socialized = false;
    private bool recieved = false;
    [SerializeField]
    private GameObject phoneObj;
    [SerializeField]
    private TextMeshProUGUI alertText;
    private TaskCompleter taskCompleter;

    // Start is called before the first frame update
    void Start()
    {
        taskCompleter = GetComponent<TaskCompleter>();
        messageCountdown = Random.Range(4.0f, 10.0f);
        if (FindObjectOfType<taskManager>().isTaskDone(taskManager.TaskOptions.Socialize))
        {
            socialized = true;
        }
    }

    public void OnPhone(InputValue value)
    {
        if (!recieved)
        {
            return;
        }
        
        if (!socialized)
        {
            socialized = true;
            taskCompleter.completeTaskNoLoad(taskManager.TaskOptions.Socialize);
            //recalculate tasks
            foreach (TaskActivator taskActivator in FindObjectsOfType<TaskActivator>())
            {
                taskActivator.recalcTasks();
            }
            phoneObj.GetComponent<Animator>().SetBool("Ringing", false);
            phoneObj.GetComponent<AudioSource>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        messageCountdown -= Time.deltaTime;
        if (messageCountdown <= 0)
        {
            if (!recieved && !socialized)
            {
                phoneObj.GetComponent<Animator>().SetBool("Ringing", true);
                phoneObj.GetComponent<AudioSource>().Play();
            }
            recieved = true;
        }
    }
}
