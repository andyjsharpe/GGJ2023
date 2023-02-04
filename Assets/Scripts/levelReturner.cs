using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelReturner : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void returnToSavedLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("toReturnTo"));
    }
}
