using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class combinationLockPuzzle : MonoBehaviour
{
    /*

    VARIABLES

    */

    // -----public variables-----
    public Sprite[] spritesForNumber; // stores sprites corresponding to the numbers on the dials
    public int[] correctAnswer = new int[] { 1, 2, 3, 4 };

    // -----Serialized variables-----

    // general UI elements:
    [SerializeField] GameObject mainPlayerUI;
    [SerializeField] GameObject[] slotImageObjects; // game objects for images to update player choice for each of the 4 dials

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


    // -----Private variables-----
    int[] userChoices = new int[] { 0, 0, 0, 0 };
    int upperBound = 5; // the upper bound that a number on a dial can go to (numbers range from 0 to this upper bound
    int numSlots = 4; // the number of slots on the combination lock system


    /*
    
    FUNCTIONS
    
    */

    // ------public functions------

    // update the user's choice on a coresponding slot in the combination lock counting sequentially upwards: (1, 2, 3, ...) (parameter-> slot: the slot that the user is changing in the dial)
    public void updateChoiceIncrement(int slot)
    {

        // reset to the start if the end of the choices on the dial at the slot selected are reached (since the choices are circular)
        if (userChoices[slot - 1] + 1 > upperBound)
        {
            userChoices[slot - 1] = 0;
        }
        else
        {
            userChoices[slot - 1] = userChoices[slot-1] + 1;
        }

        Debug.Log("SLOT: " + slot + ", CHOICE: " + userChoices[slot - 1]);
        // update image corresponding to chosen month
        updateImageSlot(slot, userChoices[slot-1]);
    }

    // update the user's choice on a coresponding slot in the combination lock counting sequentially downwards: (3, 2, 1, ...) (parameter-> slot: the slot that the user is changing in the dial)
    public void updateChoiceDecrement(int slot)
    {
       
        // reset to the end if the start of the choices on the dial at the slot selected are reached (since the choices are circular)
        if (userChoices[slot - 1] - 1 < 0)
        {
            userChoices[slot - 1] = upperBound;
        }
        else
        {
            userChoices[slot - 1] = userChoices[slot - 1] - 1;
        }

        Debug.Log("SLOT: " + slot + ", CHOICE: " + userChoices[slot - 1]);
        // update image corresponding to chosen month
        updateImageSlot(slot, userChoices[slot - 1]);
    }

    // process answers from the player
    public void processAnswer()
    {
        // if the answer was correct
        if (answerIsCorrect())
        {
            // process puzzle completion
            handlePuzzleCompletion();
        }
        // otherwise, it's wrong, display stuff to denote that
        else
        {
            // play sound for wrong answer
            audioSource.PlayOneShot(incorrectSound, 0.5f);

            Debug.Log("WRONG");
        }
    }


    // ------private functions------

    // helper function for updating image for a given slot
    void updateImageSlot(int slot, int userChoice)
    {
        slotImageObjects[slot-1].GetComponent<Image>().sprite = spritesForNumber[userChoice];
    }

    // helper function for checking if the combination that the user submitted matches up with the correct combination
    bool answerIsCorrect()
    {
        for (int i = 0; i < numSlots; i++)
        {
            // if even one of the numbers entered in the dial do not match up, deem the answer incorrect
            if (userChoices[i] != correctAnswer[i])
            {
                return false;
            }
        }

        // the number on each dial matched up with the correct corresponding numbers
        return true;
    }


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
        puzzleStorage.GetComponent<FloorCompletion>().updateFloorTwoPuzzlesCompleted(puzzleCompleteIndicator1, puzzleCompleteIndicator2, 5);
        Debug.Log("PUZZLE COMPLETE");
    }
}
