using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mathpuzzle : MonoBehaviour
{
    // -----Serialized variables-----
    // UI elements:
    [SerializeField] GameObject puzzleUIF2P1;
    [SerializeField] GameObject userInput;
    [SerializeField] GameObject questionObj;
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


    public Sprite[] puzzleQuestions;

    // -----Private variables-----
    //bool puzzleIsDone = false; // for noting down if the puzzle is complete
    bool answerSubmitted = false; // for checking if an answer has been submitted
    int playerAnswer; // stores player's answer submission
    int currStep = 1; // current step
    int finStep; // final step
    int[] answerList = new int[] { 6, 2, 25 }; // stores answers for steps (used documentation: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays)

    void Awake() {
        finStep = answerList.Length;
    }

    void Update() {
        // if user reached the end
        if (currStep == finStep+1) 
        {
            handlePuzzleCompletion();
        } 
        // if the user submitted the answer
        else if (answerSubmitted) 
        {
            answerSubmitted = false;
            processAnswer();
            userInput.GetComponent<TMP_InputField>().text = ""; // reset text input
        }
    }

    // process answers from the player
    void processAnswer() {
        // get the player input
        setPlayerAnswer();

        // if the answer was correct
        if (answerList[currStep-1] == playerAnswer) 
        {
            
            // load next step and update step
            currStep++;
            loadStep(currStep);

            // play sound for correct answer
            if (currStep <= finStep) {
                audioSource.PlayOneShot(correctSound, 0.1f);
            }

            Debug.Log("Correct, CURRSTEP: " + currStep);
        }
        // otherwise, it's wrong, display stuff to denote that
        else
        {
            // play sound for wrong answer
            audioSource.PlayOneShot(incorrectSound, 0.1f);

            Debug.Log("WRONG");
        }
    }

    // handle completion of the full puzzle
    void handlePuzzleCompletion() {
        // play completion sound (from player to handle cases where certain objects are deactivated) 
        player.GetComponent<AudioSource>().PlayOneShot(correctSound, 0.1f);

        // close puzzle & activate main player UI
        puzzleUIF2P1.SetActive(false);
        mainPlayerUI.SetActive(true);
        uiEvents.GetComponent<PopupToggle>().setPopupOpen(false);

        // deactivate the puzzle object/don't let the player interact with it anymore (since it's not going to be used again if it's done)
        puzzleObject.layer = 0;

        // let the event handler system know that this puzzle has been completed
        puzzleStorage.GetComponent<FloorCompletion>().updateFloorTwoPuzzlesCompleted(puzzleCompleteIndicator1, puzzleCompleteIndicator2, 1);
        Debug.Log("PUZZLE COMPLETE");

    }

    // update UI for steps
    void loadStep(int step) {
        questionObj.GetComponent<Image>().sprite = puzzleQuestions[step-1];
    }

    // -----SETTERS/GETTERS-----
    //public void setPuzzleDone(bool isDone) {
    //    puzzleIsDone = isDone;
    //}

    public void setAnswerSubmitted(bool submitted) {
        answerSubmitted = submitted;
    }

    public void setPlayerAnswer() {
        int.TryParse(userInput.GetComponent<TMP_InputField>().text, out playerAnswer);
    }
}
