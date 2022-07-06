using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// mini notes
// deactivate puzzle object (change layer to undefined) after puzzle is done

public class PuzzleF1P1 : MonoBehaviour
{
    // -----Serialized variables-----
    // UI elements:
    [SerializeField] GameObject uiEvents;
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject puzzleUIF1P1;
    [SerializeField] GameObject userInput;

    // images:
    // [SerializeField] Image numberOne;
    // [SerializeField] Image numberFour;
    // [SerializeField] Image numberFive;

    // other:
    [SerializeField] GameObject puzzleObject;

    // -----Private variables-----
    bool puzzleIsDone = false; // for noting down if the puzzle is complete
    bool answerSubmitted = false; // for checking if an answer has been submitted
    int playerAnswer;
    int currStep = 1; // current step
    int finStep = 5; // final step
    // used documentation: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays
    int[] answerList = new int[] { 5, 6, 7, 8, 9 }; // stores answers for steps


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
            // TODO: make popup for correct answer

            // load next step and update step
            currStep++;
            loadStep(currStep);

            Debug.Log("CURRSTEP: " + currStep);
        }
        // otherwise, it's wrong, display stuff to denote that
        else
        {
            // TODO: make popup for wrong answer
            Debug.Log("WRONG");
        }
    }

    // handle completion of the full puzzle
    void handlePuzzleCompletion() {
        // TODO: disable "Interactable" layer for this puzzle (make completed puzzle non-interactable)

        // close puzzle
        uiEvents.GetComponent<PopupToggle>().popupIsOpen = false;
        mainUI.SetActive(true);
        puzzleUIF1P1.SetActive(false);

        // smite the door (basically let player enter next room)

        // display congratulations popup
        Debug.Log("PUZZLE COMPLETE");
    }

    // update UI for steps
    void loadStep(int step) {
        switch (step)
        {
            case 2:
                loadStepTwo();
                break;          
            case 3:
                loadStepThree();
                break;
            case 4:
                loadStepFour();
                break;
            case 5:
                loadStepFive();
                break;
        }
    }

    // TODO: make updates for UI
    // step 2
    void loadStepTwo() {

    }

    // step 3
    void loadStepThree() {
        
    }

    // step 4
    void loadStepFour() {
        
    }

    // step 5
    void loadStepFive() {
        
    }

    // -----SETTERS/GETTERS-----
    public void setPuzzleDone(bool isDone) {
        puzzleIsDone = isDone;
    }

    public void setAnswerSubmitted(bool submitted) {
        answerSubmitted = submitted;
    }

    public void setPlayerAnswer() {
        Debug.Log("TEST: " + userInput.GetComponent<TMP_InputField>().text);
        int.TryParse(userInput.GetComponent<TMP_InputField>().text, out playerAnswer);
        Debug.Log("TEST2: " + playerAnswer);
    }
}
