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
    private bool phoneUp = false;
    [SerializeField]
    private GameObject phoneObj;
    [SerializeField]
    private TextMeshProUGUI alertText;
    private TaskCompleter taskCompleter;

    // Start is called before the first frame update
    void Start()
    {
        taskCompleter = GetComponent<TaskCompleter>();
        messageCountdown = Random.Range(2.0f, 8.0f);
        phoneUp = false;
    }

    public void OnPhone(InputValue value)
    {
        if (!recieved)
        {
            return;
        }
        
        //toggle phone
        if (phoneUp)
        {
            phoneObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-40.0f, -640.0f, 0.0f);
            alertText.text = "[Q]: Check";
            if (!socialized)
            {
                socialized = true;
                taskCompleter.completeTaskNoLoad(taskManager.TaskOptions.Socialize);
                //recalculate tasks
                foreach (TaskActivator taskActivator in FindObjectsOfType<TaskActivator>())
                {
                    taskActivator.recalcTasks();
                }
            }
        } else if (!socialized)
        {
            phoneObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-40.0f, 0.0f, 0.0f);
            alertText.text = "[Q]: Answer";
        } else
        {
            phoneObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-40.0f, 0.0f, 0.0f);
            alertText.text = "[Q]: Close";
        }
        phoneUp = !phoneUp;
    }

    // Update is called once per frame
    void Update()
    {
        messageCountdown -= Time.deltaTime;
        if (messageCountdown <= 0)
        {
            phoneObj.SetActive(true);
            recieved = true;
        }
    }
}
