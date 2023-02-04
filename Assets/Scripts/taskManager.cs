using System;
using UnityEditor;
using UnityEngine;

public class taskManager : MonoBehaviour
{
    [SerializeField]
    private SceneAsset associatedScene; //the main scene this house or minigame belongs to
    [SerializeField]
    private SceneAsset nextScene; //the next main scene

    public enum TaskOptions
    {
        None,
        Water,
        Fertilize,
        TillWeeds,
        Clean,
        Read,
        Eat
    }

    //marks a task as done
    private void markTaskDone(TaskOptions option)
    {
        PlayerPrefs.SetInt(associatedScene.name + "-" + option.ToString(), 1);
    }

    public bool isTaskDone(TaskOptions option)
    {
        return PlayerPrefs.GetInt(associatedScene.name + "-" + option.ToString()) == 1;
    }

    //clears all tasks in the next level
    private void clearNextLevel()
    {
        string[] taskNames = System.Enum.GetNames(typeof(TaskOptions));
        foreach (string taskName in taskNames)
        {
            PlayerPrefs.SetInt(nextScene.name + "-" + taskName, 0);
        }
    }

    //checks if all tasks in the associated scene are done
    public bool areAllTasksDone()
    {
        foreach (taskManager.TaskOptions task in Enum.GetValues(typeof(taskManager.TaskOptions)))
        {
            if (task == TaskOptions.None)
            {
                continue;
            }
            
            if (!isTaskDone(task))
            {
                return false;
            }
        }
        return true;
    }
}
