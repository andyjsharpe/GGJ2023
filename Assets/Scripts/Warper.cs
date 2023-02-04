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
        SceneManager.LoadScene(toWarpTo.name);
    }
}
