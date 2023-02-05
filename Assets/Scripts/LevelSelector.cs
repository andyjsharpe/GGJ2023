using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using static taskManager;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textField;
    [SerializeField] LevelMenuManager lvlManger;
    public SceneAsset toChangeTo;
    public int levelNum;

   public void Click()
    {
        PlayerPrefs.SetFloat("sanityTarget", levelNum / 6);

        //clear the playerprefs in the next level
        string[] taskNames = System.Enum.GetNames(typeof(TaskOptions));
        foreach (string taskName in taskNames)
        {
            PlayerPrefs.SetInt(toChangeTo.name + "-" + taskName, 0);
        }

        //reset timer
        PlayerPrefs.SetFloat(toChangeTo.name + "-" + "time", 120);

        SceneManager.LoadScene(toChangeTo.name);
    }

    // Non-Click Methods
    public void ChangeText(string text)
    {
        textField.text = text;
    }
}
