using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShifter : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;

    public void ShiftGridLeft()
    {
        // Start Shifting Coroutine (Left) if aren't already shifting
        LevelMenuManager manager = levelMenu.GetComponent<LevelMenuManager>();
        if (!manager.isShifting)
            StartCoroutine(manager.Shift(false));
    }

    public void ShiftGridRight()
    {
        // Start Shifting Coroutine (Right) if aren't already shifting
        LevelMenuManager manager = levelMenu.GetComponent<LevelMenuManager>();
        if (!manager.isShifting)
            StartCoroutine(manager.Shift(true));
    }
}
