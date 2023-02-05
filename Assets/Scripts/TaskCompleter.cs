using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskCompleter : MonoBehaviour
{
    private string getSceneNameFromIndex(int index)
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(index);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

        return sceneName;
    }
    
    public void completeTask(taskManager.TaskOptions option)
    {
        int parentSceneid = PlayerPrefs.GetInt("toReturnTo");
        string parentName = getSceneNameFromIndex(parentSceneid);

        string lookup = parentName + "-" + option.ToString();
        PlayerPrefs.SetInt(lookup, 1);

        Debug.Log(lookup + " set to 1");

        SceneManager.LoadScene(parentSceneid);
    }
    public void incompleteTask(taskManager.TaskOptions option)
    {
        int parentSceneid = PlayerPrefs.GetInt("toReturnTo");
        string parentName = getSceneNameFromIndex(parentSceneid);

        string lookup = parentName + "-" + option.ToString();
        PlayerPrefs.SetInt(lookup, 0);

        Debug.Log(lookup + " set to 0");

        SceneManager.LoadScene(parentSceneid);
    }
}
