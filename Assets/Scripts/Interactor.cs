using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// from tutorial: https://www.youtube.com/watch?v=lZThP8KG1W0
public class Interactor : MonoBehaviour
{
    UnityEvent onInteract;
    public LayerMask interactableLayermask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // send ray from camera to check for interactable object
        RaycastHit hit; 

        // (refer to documentation for Physics.Raycast: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html)
        // send raycast from origin (the center of the camera) torward where they are looking (forward). Output to "hit" variable. Max distance is 1. Make sure it hits an interactable.  
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3, interactableLayermask)) {
            // get specific action of interactable
            onInteract = hit.collider.GetComponent<Interactable>().onInteract;
            // do action when user left clicks interactable
            if (Input.GetMouseButtonDown(0)) {
                onInteract.Invoke();
            }
        }
    }
}
