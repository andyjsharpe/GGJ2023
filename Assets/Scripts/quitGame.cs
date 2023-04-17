using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{
    public void doQuit()
    {
        Application.Quit();
        Debug.LogError("Game Quits here");
    }
}
