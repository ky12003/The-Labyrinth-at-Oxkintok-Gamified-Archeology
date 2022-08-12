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
    // check if puzzle is open (special case)
    public bool puzzleIsOpen = false;
    // check if the player should be able to open the notebook (since notebook is not allowed to be opened until
    public bool notebookIsActive = false;

    // variables for UI elements (main UI, notebook, & puzzles)
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject notebook;
    [SerializeField] GameObject pauseMenu;
    public AudioSource audioSource;

    GameObject currPuzzle;

    void Update()
    {
        // Check for button press, do corresponding actions (E key: open notebook)
        if ((Input.GetKeyDown(KeyCode.E)) && !popupIsOpen && notebookIsActive) {
            openNotebook();
        } else if ((Input.GetKeyDown(KeyCode.Escape)) && !popupIsOpen) {
            openPauseMenu();
        }   
    }

    public void setPopupOpen(bool isOpen) 
    {
        if (!puzzleIsOpen)
        {
            popupIsOpen = isOpen;
        }
        
    }

    public void deactivateNotebook()
    {
        if (puzzleIsOpen)
        {
            notebook.SetActive(false);
            currPuzzle.SetActive(true);
        } else
        {
            notebook.SetActive(false);
            mainUI.SetActive(true);
            popupIsOpen = false;
        }
    }

    public void setPuzzleOpen(bool puzzleOpen)
    {
        puzzleIsOpen = puzzleOpen;
    }

    public void setCurrentOpenPuzzle(GameObject puzzle)
    {
        currPuzzle = puzzle;
    }

    public void activateNotebook()
    {
        notebookIsActive = true;
    }

    public void openNotebook()
    {
        setPopupOpen(true);
        notebook.SetActive(true);
        mainUI.SetActive(false);
        if (puzzleIsOpen)
        {
            currPuzzle.SetActive(false);
        }
    }

    public void openPauseMenu()
    {
        setPopupOpen(true);
        pauseMenu.SetActive(true);
        mainUI.SetActive(false);
    }

    
}
