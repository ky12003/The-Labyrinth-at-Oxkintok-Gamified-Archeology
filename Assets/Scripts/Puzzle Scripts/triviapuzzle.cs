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

    // -----Serialized variables-----
    // UI elements:
    [SerializeField] GameObject puzzleUIF2P4;
    [SerializeField] GameObject riddleTextObject;
    [SerializeField] GameObject mainPlayerUI;
    [SerializeField] GameObject[] buttonTextObjects;

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
    int playerAnswer; // stores player's answer submission
    int currStep = 1; // current step
    int finStep; // final step
    int[] answerList = new int[] { 3, 1, 2, 4 }; // stores answers for steps (used documentation: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays)
    // all riddles
    string[] riddleList = new string[] {
        "How many days does the Tzolkin calendar consist of?", 
        "The last month of this calendar system consisted of 5 “unlucky” days.", 
        "How many major calendars did the Mayans use?", 
        "Out of all the time periods in the Long Count calendar, which takes the longest?"
    };
    // all choices for each of the question parts (multidimentional array documentation: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays)
    string[,] choiceList = new string[,]
    {
        {"360", "320", "260", "100" },
        {"Haab'", "Long", "Tzolkin", "Satunsat" },
        {"2", "3", "4", "1"},
        {"Uinal", "K'in", "Tun", "B'aktun" }
    };

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            uiEvents.GetComponent<PopupToggle>().openNotebook();
        }
    }

    // ------public functions------
    // process an answer from the player (parameter: the button ID corresponding to the choice)
    public void processAnswer(int buttonOption)
    {
        if (buttonOption == answerList[currStep-1])
        {
            currStep++;
            loadStep(currStep);

            if (currStep <= finStep)
            {
                audioSource.PlayOneShot(correctSound, 0.1f);
            }

            Debug.Log("Correct, CURRSTEP: " + currStep);
        }
        // otherwise, it's wrong, do stuff to denote that
        else
        {
            // play sound for wrong answer
            audioSource.PlayOneShot(incorrectSound, 0.1f);

            Debug.Log("WRONG");
        }


    }

    // ------private functions------
    // update UI for steps
    void loadStep(int step)
    {
        riddleTextObject.GetComponent<TMP_Text>().text = riddleList[step - 1];
        for (int i = 0; i < 4; i++)
        {
            buttonTextObjects[i].GetComponent<TMP_Text>().text = choiceList[step - 1, i];
        }
    }


    // handle completion of the full puzzle
    void handlePuzzleCompletion()
    {
        // play completion sound (from player to handle cases where certain objects are deactivated) 
        player.GetComponent<AudioSource>().PlayOneShot(correctSound, 0.5f);

        // close puzzle & activate main player UI
        gameObject.SetActive(false);
        mainPlayerUI.SetActive(true);
        uiEvents.GetComponent<PopupToggle>().setPuzzleOpen(false);
        uiEvents.GetComponent<PopupToggle>().setPopupOpen(false);

        // deactivate the puzzle object/don't let the player interact with it anymore (since it's not going to be used again if it's done)
        puzzleObject.layer = 0;

        // let the event handler system know that this puzzle has been completed
        puzzleStorage.GetComponent<FloorCompletion>().updateFloorTwoPuzzlesCompleted(puzzleCompleteIndicator1, puzzleCompleteIndicator2, 4);
        Debug.Log("PUZZLE COMPLETE");


    }

}
