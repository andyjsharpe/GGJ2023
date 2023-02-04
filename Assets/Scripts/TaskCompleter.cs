using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskCompleter : MonoBehaviour
{
    public void completeTask(taskManager.TaskOptions option)
    {
        int parentSceneid = PlayerPrefs.GetInt("toReturnTo");
        Scene parentScene = SceneManager.GetSceneByBuildIndex(parentSceneid);
        PlayerPrefs.SetInt(parentScene.name + "-" + option.ToString(), 1);

        SceneManager.LoadScene(parentSceneid);
    }
    public void incompleteTask(taskManager.TaskOptions option)
    {
        int parentSceneid = PlayerPrefs.GetInt("toReturnTo");
        Scene parentScene = SceneManager.GetSceneByBuildIndex(parentSceneid);
        PlayerPrefs.SetInt(parentScene.name + "-" + option.ToString(), 0);

        SceneManager.LoadScene(parentSceneid);
    }
}
