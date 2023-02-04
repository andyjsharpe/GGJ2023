using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private float interactDist = 4;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private GameObject interactionPopup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interactable interactable = checkInteraction();
        if (interactable != null)
        {
            interactionPopup.SetActive(true);
        } else
        {
            interactionPopup.SetActive(false);
        }
    }

    private Interactable checkInteraction()
    {
        //raycast to center of screen
        Camera mainCam = Camera.main;
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, interactDist, mask))
        {
            return hit.transform.GetComponent<Interactable>();
        }
        return null;
    }

    public void doInteraction()
    {
        Interactable interactable = checkInteraction();
        if (interactable != null)
        {
            interactable.interact();
        }
    }
}
