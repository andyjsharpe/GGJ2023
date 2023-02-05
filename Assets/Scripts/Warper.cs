using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warper : MonoBehaviour
{
    [SerializeField]
    private SceneAsset toWarpTo;

    public void doWarp()
    {
        PlayerPrefs.SetInt("toReturnTo", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(toWarpTo.name);
    }
}
