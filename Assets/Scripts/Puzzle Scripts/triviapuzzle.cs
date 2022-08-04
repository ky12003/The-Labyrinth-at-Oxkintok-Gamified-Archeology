using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class triviapuzzle : MonoBehaviour
{
    /*

    VARIABLES

    */

    // -----Public variables------
    public Sprite[] dayExampleImages;

    // -----Serialized variables-----
    // UI elements:
    [SerializeField] GameObject puzzleUIF2P4;
    [SerializeField] GameObject dayExampleImageObject;
    [SerializeField] GameObject mainPlayerUI;
    [SerializeField] GameObject buttonOne;
    [SerializeField] GameObject buttonTwo;
    [SerializeField] GameObject buttonThree;
    [SerializeField] GameObject buttonFour;

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
    bool puzzleIsDone = false; // for noting down if the puzzle is complete
    bool answerSubmitted = false; // for checking if an answer has been submitted
    int playerAnswer; // stores player's answer submission
    int currStep = 1; // current step
    int finStep; // final step
    int[] answerList = new int[] { 3, 1, 2 }; // stores answers for steps (used documentation: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays)

    /*
    
    FUNCTIONS

    */

    // -----unity functions------
    void Awake()
    {
        finStep = answerList.Length;
    }

    void Update()
    {
        // if user reached the end
        if (currStep == finStep + 1)
        {
            handlePuzzleCompletion();
        }
        // if the user submitted the answer
        else if (answerSubmitted)
        {
            answerSubmitted = false;
            //processAnswer();
        }
    }

    // ------public functions------
    // set a certain button to be pressed (parameter description for button option: 1 = long calendar, 2 = haab calendar, 3 = tzolkin calendar)
    public void setButtonPressed(int buttonOption)
    {
        playerAnswer = buttonOption;
        answerSubmitted = true;
    }

    // ------private functions------
    // update UI for steps
    void loadStep(int step)
    {
        dayExampleImageObject.GetComponent<Image>().sprite = dayExampleImages[step - 1];
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
        puzzleStorage.GetComponent<FloorCompletion>().updateFloorTwoPuzzlesCompleted(puzzleCompleteIndicator1, puzzleCompleteIndicator2);
        Debug.Log("PUZZLE COMPLETE");
    }
}
