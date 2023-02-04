using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class taskManager : MonoBehaviour
{
    [SerializeField]
    private SceneAsset associatedScene; //the main scene this house or minigame belongs to
    [SerializeField]
    private SceneAsset nextScene; //the next main scene
    [SerializeField]
    private SceneAsset failScene;
    [SerializeField]
    private TextMeshProUGUI clock;
    [SerializeField]
    private TaskOptions[] requiredTasks;
    [SerializeField]
    private TaskOptions[] optionalTasks;

    public enum TaskOptions
    {
        None,
        Water,
        Fertilize,
        TillWeeds,
        Clean,
        Read,
        Cook,
        Socialize
    }

    private void Update()
    {
        float time = PlayerPrefs.GetFloat(associatedScene.name + "-" + "time");
        time -= Time.deltaTime;
        clock.text = ((int)time).ToString();
        PlayerPrefs.SetFloat(associatedScene.name + "-" + "time", time);

        //level is over
        if (time <= 0)
        {
            levelTransition();
        } else if (allDone())
        {
            levelTransition();
        }
    }

    private void levelTransition()
    {
        //reset timer
        PlayerPrefs.SetFloat(associatedScene.name + "-" + "time", 20);

        //if level not completed 
        if (!requiredDone())
        {
            //clear the playerprefs in this level
            clearThisLevel();
            PlayerPrefs.SetInt("toReturnTo", SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Failed");
            SceneManager.LoadScene(failScene.name);
            return;
        }
        
        //increase sanity based on number of optional tasks done
        float sanityTarget = PlayerPrefs.GetFloat("sanityTarget");
        sanityTarget += Mathf.Min((1 - optionalDoneRatio())/6.0f, 1.0f); //makes it so if no optional tasks are done, sanity will rech last by the last level
        PlayerPrefs.SetFloat("sanityTarget", sanityTarget);

        //clear the playerprefs in this level
        clearThisLevel();
        //clear the playerprefs in the next level
        clearNextLevel();

        //open next scene
        SceneManager.LoadScene(nextScene.name);
    }

    private bool requiredDone()
    {
        foreach (taskManager.TaskOptions task in requiredTasks)
        {
            if (!isTaskDone(task))
            {
                return false;
            }
        }
        return true;
    }

    private float optionalDoneRatio()
    {
        int doneCount = 0;
        foreach (taskManager.TaskOptions task in optionalTasks)
        {
            if (isTaskDone(task))
            {
                doneCount += 1;
            }
        }
        return doneCount/optionalTasks.Length;
    }

    private bool allDone()
    {
        return requiredDone() && optionalDoneRatio() == 1;
    }

    public bool isTaskDone(TaskOptions option)
    {
        return PlayerPrefs.GetInt(associatedScene.name + "-" + option.ToString()) == 1;
    }

    //clears all tasks in the next level
    private void clearLevel(SceneAsset scene)
    {
        string[] taskNames = System.Enum.GetNames(typeof(TaskOptions));
        foreach (string taskName in taskNames)
        {
            PlayerPrefs.SetInt(scene.name + "-" + taskName, 0);
        }
    }

    //clears all tasks in the next level
    private void clearThisLevel()
    {
        clearLevel(associatedScene);
    }

    //clears all tasks in the next level
    private void clearNextLevel()
    {
        clearLevel(nextScene);
    }
}
