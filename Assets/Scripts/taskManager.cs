using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class taskManager : MonoBehaviour
{
    [SerializeField]
    private int associatedScene; //the main scene this house or minigame belongs to
    [SerializeField]
    private int nextScene; //the next main scene
    [SerializeField]
    private int failScene;
    [SerializeField]
    private int winScene;
    [SerializeField]
    private GameObject[] clocks;
    [SerializeField]
    private TaskOptions[] requiredTasks;
    [SerializeField]
    private TaskOptions[] optionalTasks;
    [SerializeField]
    private int levelNum = 1;

    public enum TaskOptions
    {
        None,
        Water,  //Done
        Fertilize,  //Done
        TillWeeds,  //Done
        CleanPlants,    //Done
        Read,   //Done
        Cook,   //In progress
        Socialize,  //In progress
        CheckRoom  //In progress
    }

    private void Start()
    {
        PlayerPrefs.SetInt(LevelMenuManager.LEVEL_REACHED_KEY, levelNum);
        PlayerPrefs.SetInt("toReturnTo", FindObjectOfType<taskManager>().getSceneIndexFromName(associatedScene));
    }

    private string getSceneNameFromIndex(int index)
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(index);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

        return sceneName;
    }

    private void Update()
    {
        float time = PlayerPrefs.GetFloat(getSceneNameFromIndex(associatedScene) + "-" + "time");
        time -= Time.deltaTime;
        float doneRatio = 1 - time / 120;
        int timeRatio = (int)(Mathf.Min(clocks.Length * doneRatio, clocks.Length - 1));
        foreach (GameObject clock in clocks)
        {
            clock.SetActive(false);
        }
        clocks[timeRatio].SetActive(true);
        PlayerPrefs.SetFloat(getSceneNameFromIndex(associatedScene) + "-" + "time", time);

        //level is over
        if (time <= 0)
        {
            levelTransition();
        } else if (allDone())
        {
            levelTransition();
        }
    }

    public int getSceneIndexFromName(int scene)
    {
        int buildIndex = SceneManager.GetSceneByName(getSceneNameFromIndex(scene)).buildIndex;

        //string scenePath = SceneManager.GetSceneByName(scene.name).path;
        //int buildIndex = SceneUtility.GetBuildIndexByScenePath(scenePath);

        return buildIndex;
    }

    private void levelTransition()
    {
        //reset timer
        PlayerPrefs.SetFloat(getSceneNameFromIndex(associatedScene) + "-" + "time", 120);
        float sanityTarget = PlayerPrefs.GetFloat("sanityTarget");

        //if level not completed 
        if (!requiredDone())
        {
            //increase sanity by 1/6
            sanityTarget += 1 / 6.0f;
            sanityTarget = Mathf.Min(sanityTarget, 1);
            PlayerPrefs.SetFloat("sanityTarget", sanityTarget);

            //clear the playerprefs in this level
            clearThisLevel();
            PlayerPrefs.SetInt("toReturnTo", SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Failed");
            SceneManager.LoadScene(failScene);
            return;
        }

        //increase sanity based on number of optional tasks done
        sanityTarget += (1 - optionalDoneRatio()) / 6.0f; //makes it so if no optional tasks are done, sanity will reach last by the last level
        sanityTarget = Mathf.Min(sanityTarget, 1);
        PlayerPrefs.SetFloat("sanityTarget", sanityTarget);

        //clear the playerprefs in this level
        clearThisLevel();
        //clear the playerprefs in the next level
        clearNextLevel();

        PlayerPrefs.SetString("toReturnToS", getSceneNameFromIndex(nextScene));

        //open next scene
        SceneManager.LoadScene(winScene);
    }

    private bool requiredDone()
    {
        foreach (TaskOptions task in requiredTasks)
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
        if (optionalTasks.Length == 0)
        {
            return 1;
        }
        
        int doneCount = 0;
        foreach (TaskOptions task in optionalTasks)
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
        string lookup = getSceneNameFromIndex(associatedScene) + "-" + option.ToString();
        bool check = PlayerPrefs.GetInt(lookup) == 1;
        //Debug.Log(lookup + " returns: " + check.ToString());
        return check;
    }

    //clears all tasks in the next level
    private void clearLevel(int scene)
    {
        string[] taskNames = System.Enum.GetNames(typeof(TaskOptions));
        foreach (string taskName in taskNames)
        {
            PlayerPrefs.SetInt(getSceneNameFromIndex(scene) + "-" + taskName, 0);
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
