using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static taskManager;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textField;
    [SerializeField] LevelMenuManager lvlManger;
    public int toChangeTo;
    public int levelNum;

    private string getSceneNameFromIndex(int index)
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(index);
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

        return sceneName;
    }

    public void Click()
    {
        PlayerPrefs.SetFloat("sanityTarget", levelNum / 6);

        //clear the playerprefs in the next level
        string[] taskNames = System.Enum.GetNames(typeof(TaskOptions));
        foreach (string taskName in taskNames)
        {
            PlayerPrefs.SetInt(getSceneNameFromIndex(toChangeTo) + "-" + taskName, 0);
        }

        //reset timer
        PlayerPrefs.SetFloat(getSceneNameFromIndex(toChangeTo) + "-" + "time", 90);

        SceneManager.LoadScene(toChangeTo);
    }

    // Non-Click Methods
    public void ChangeText(string text)
    {
        textField.text = text;
    }
}
