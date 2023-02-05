using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warper : MonoBehaviour
{
    [SerializeField]
    private int toWarpTo;

    public void doWarp()
    {
        PlayerPrefs.SetInt("toReturnTo", SceneManager.GetActiveScene().buildIndex);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        SceneManager.LoadScene(toWarpTo);
    }
}
