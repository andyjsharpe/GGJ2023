using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAdvancer : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void goToSavedLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("toReturnToS"));
    }
}
