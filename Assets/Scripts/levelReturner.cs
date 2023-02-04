using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelReturner : MonoBehaviour
{
    public void returnToSavedLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("toReturnTo"));
    }
}
