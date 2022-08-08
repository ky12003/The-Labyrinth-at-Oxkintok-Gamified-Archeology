using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpuzzle : MonoBehaviour
{
    /*

    VARIABLES

    */

    // -----public variables-----

    // -----Serialized variables-----

    // general UI elements:
    [SerializeField] GameObject mainPlayerUI;

    // sounds:
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip correctSound;
    [SerializeField] AudioClip incorrectSound;

    // other:
    [SerializeField] GameObject uiEvents;
    [SerializeField] GameObject puzzleStorage;
    [SerializeField] GameObject puzzleObject;
    [SerializeField] GameObject puzzleCompleteIndicator1;
    [SerializeField] GameObject puzzleCompleteIndicator2;
    [SerializeField] GameObject player;

    /*

    FUNCTIONS

    */

    // ------public functions------
    public void processCorrectAnswer()
    {
        handlePuzzleCompletion();
    }

    public void processIncorrectAnswer()
    {
        // play sound for wrong answer
        audioSource.PlayOneShot(incorrectSound, 0.5f);

        Debug.Log("WRONG");
    }

    //  ------private functions------
    // handle completion of the full puzzle
    void handlePuzzleCompletion()
    {
        // play completion sound (from player to handle cases where certain objects are deactivated) 
        player.GetComponent<AudioSource>().PlayOneShot(correctSound, 0.5f);

        // close puzzle & activate main player UI
        gameObject.SetActive(false);
        mainPlayerUI.SetActive(true);
        uiEvents.GetComponent<PopupToggle>().setPopupOpen(false);

        // deactivate the puzzle object/don't let the player interact with it anymore (since it's not going to be used again if it's done)
        puzzleObject.layer = 0;

        // let the event handler system know that this puzzle has been completed
        puzzleStorage.GetComponent<FloorCompletion>().updateFloorTwoPuzzlesCompleted(puzzleCompleteIndicator1, puzzleCompleteIndicator2, 3);
        Debug.Log("PUZZLE COMPLETE");
    }
}
