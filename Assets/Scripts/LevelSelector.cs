using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textField;
    [SerializeField] LevelMenuManager lvlManger;

   public void Click()
    {

        // Specify 

        //TODO: Code to start game on clicked level
    }

    // Non-Click Methods
    public void ChangeText(string text)
    {
        textField.text = text;
    }
}
