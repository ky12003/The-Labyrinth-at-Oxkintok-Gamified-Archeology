using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// mini notes
// deactivate puzzle object (change layer to undefined) after puzzle is done

public class PuzzleF1P1 : MonoBehaviour
{
    // -----Serialized variables-----
    // UI elements:
    [SerializeField] GameObject puzzleUIF1P1;
    [SerializeField] GameObject player;
    [SerializeField] GameObject userInput;
    [SerializeField] GameObject questionObj;
    [SerializeField] GameObject answerPromptObj;
    [SerializeField] GameObject triviaUI;
    [SerializeField] GameObject pageObject;

    // sounds:
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip correctSound;
    [SerializeField] AudioClip incorrectSound;
    [SerializeField] AudioClip completionSound;

    // other:
    [SerializeField] GameObject puzzleObject;
    [SerializeField] GameObject doorObject;

    public Sprite[] puzzleQuestions;
    public Sprite[] puzzlePrompts;

    // -----Private variables-----
    bool puzzleIsDone = false; // for noting down if the puzzle is complete
    bool answerSubmitted = false; // for checking if an answer has been submitted
    int playerAnswer; // stores player's answer submission
    int currStep = 1; // current step
    int finStep; // final step
    int[] answerList = new int[] { 5, 7, 0, 16, 19 }; // stores answers for steps (used documentation: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays)
    PageUpdate pageUpdate; // for updating page (in this case, page 1)

    void Awake() {
        finStep = answerList.Length;
        pageUpdate = pageObject.GetComponent<PageUpdate>();
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
            // update page
            pageUpdate.updatePart(currStep);
            
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
        player.GetComponent<AudioSource>().PlayOneShot(completionSound, 0.1f);

        // close puzzle & activate trivia popup
        puzzleUIF1P1.SetActive(false);
        triviaUI.SetActive(true);
        doorObject.SetActive(false);

        // smite the door (basically let player enter next room)

        // display congratulations popup
        Debug.Log("PUZZLE COMPLETE");
    }

    // update UI for steps
    void loadStep(int step) {
        questionObj.GetComponent<Image>().sprite = puzzleQuestions[step-1];
        answerPromptObj.GetComponent<Image>().sprite = puzzlePrompts[step-1];
    }

    // -----SETTERS/GETTERS-----
    public void setPuzzleDone(bool isDone) {
        puzzleIsDone = isDone;
    }

    public void setAnswerSubmitted(bool submitted) {
        answerSubmitted = submitted;
    }

    public void setPlayerAnswer() {
        int.TryParse(userInput.GetComponent<TMP_InputField>().text, out playerAnswer);
    }
}
