using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Events;

// used for activating popup menus (includes notebook and puzzles)
public class PopupToggle : MonoBehaviour
{
    // for events if needed: https://docs.unity3d.com/ScriptReference/Events.UnityEvent.AddListener.html

    // check if another popup menu is currently open (currently set to false since there are no popups implemented yet)
    public bool popupIsOpen = false;

    // variables for UI elements (main UI, notebook, & puzzles)
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject notebook;
    [SerializeField] GameObject puzzleUIF1P1;
    [SerializeField] GameObject puzzleUIF1P2;

    void Update()
    {
        // Check for button press, do corresponding actions (E key: open notebook)
        if ((Input.GetKeyDown(KeyCode.E)) && !popupIsOpen) {
            popupIsOpen = true;
            notebook.SetActive(true);
            mainUI.SetActive(false);
        } 
    }

    public void setPopupOpen(bool isOpen) 
    {
        popupIsOpen = isOpen;
    }

}
