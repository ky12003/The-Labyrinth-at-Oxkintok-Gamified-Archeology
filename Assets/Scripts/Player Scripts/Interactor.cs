using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// from tutorial: https://www.youtube.com/watch?v=lZThP8KG1W0
public class Interactor : MonoBehaviour
{
    [SerializeField] GameObject uiEvents;

    UnityEvent onInteract;
    UnityEvent onLook;
    UnityEvent onNoInteraction;
    GameObject prevHit; // the previously hit game object
    public LayerMask interactableLayermask;
    public int raycastRange = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // send ray from camera to check for interactable object
        RaycastHit hit; 

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward);
        // (refer to documentation for Physics.Raycast: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html)
        // send raycast from origin (the center of the camera) torward where they are looking (forward). Output to "hit" variable. Max distance is 5. Make sure it hits an interactable.  
        // also check if a popup is already open at the time, do not activate interactor if so.
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, raycastRange, interactableLayermask) && !uiEvents.GetComponent<PopupToggle>().popupIsOpen) {
            // get specific action of interactable (when looking at it)
            onLook = hit.collider.GetComponent<Interactable>().onLook;
            // get specific action of interactable (when interacting with it using mouse key)
            onInteract = hit.collider.GetComponent<Interactable>().onInteract;

            prevHit = hit.collider.gameObject;

            // do action when user looks at interactable
            onLook.Invoke();

            // do action when user left clicks interactable
            if (Input.GetMouseButtonDown(0)) {
                onInteract.Invoke();
            }
        } else {
            onNoInteraction = prevHit.GetComponent<Interactable>().onNoInteraction;
            onNoInteraction.Invoke();
        }
    }
}
