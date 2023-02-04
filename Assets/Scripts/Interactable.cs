using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent interactEvent;

    public void interact()
    {
        Debug.Log("interacting");
        if (interactEvent != null) {
            interactEvent.Invoke(); 
        }
    }
}
