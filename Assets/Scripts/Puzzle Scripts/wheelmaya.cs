using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wheelmaya : MonoBehaviour
{
    /*

    VARIABLES

    */

    // -----public variables-----
    public Sprite riddleImg; // stores the image for the riddle
    public int monthAnswer; // stores answer for the "month" portion of the answer
    public int DayAnswer; // stores answer dfor the "Day" portion of the answer
    public Sprite[] daySprites;
    public Sprite[] monthSprites;

    // -----Serialized variables-----
    // wheel elements
    [SerializeField] GameObject wheelLeft;
    [SerializeField] GameObject wheelRight;

    // general UI elements:
    [SerializeField] GameObject mainPlayerUI;
    [SerializeField] GameObject dayImageObject;
    [SerializeField] GameObject monthImageObject;

    // sounds:
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip correctSound;
    [SerializeField] AudioClip incorrectSound;

    // other:
    [SerializeField] GameObject uiEvents;
    [SerializeField] GameObject puzzleStorage;
    [SerializeField] GameObject puzzleObject;
    [SerializeField] GameObject player;

    // -----Private variables-----
    int userChoiceDay = 1; // stores user's choice for the "Day"
    int userChoiceMonth = 1; // stores user's choice for the "month"
    int dayChoices = 20; // number of choices on left wheel
    int monthChoices = 19; // number of choices on right wheel

    /*
    
    FUNCTIONS

    */

    // -----unity functions------
    //void update()
    //{
    //    // process user answer if the answer is submitted
    //    if (answerSubmitted)
    //    {
    //        answerSubmitted = false;
    //        processAnswer();
    //    }
    //}

    // ------public functions------
    // process answers from the player
    public void processAnswer()
    {
        // if the answer was correct
        if (userChoiceMonth == monthAnswer && userChoiceDay == DayAnswer)
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

    // functions for triggering left wheel (up: counterclockwwise, down: clockwwise)
    public void handleLeftUpRotation()
    {
        // rotate the wheel counterclockwise
        rotateWheel(wheelLeft, dayChoices);
        // (subtract from the current user's day "choice" *eg. if the selected day is 4, it would become 3);
        updateChoiceDay(true);
    }

    public void handleLeftDownRotation()
    {
        // rotate the wheel clockwise
        rotateWheel(wheelLeft, -dayChoices);
        // (add to the current user's day "choice" *eg. if the selected day is 4, it would become 5);
        updateChoiceDay(false);
    }

    // functions for triggering right wheel (up: clockwise, down: counterclockwwise)
    public void handleRightUpRotation()
    {
        // rotate the wheel clockwise
        rotateWheel(wheelRight, -monthChoices);
        // (subtract from the current user's month "choice" *eg. if the selected month is 4, it would become 3);
        updateChoiceMonth(true);
    }
    public void handleRightDownRotation()
    {
        // rotate the wheel counterclockwise
        rotateWheel(wheelRight, monthChoices);
        // (add to the current user's month "choice" *eg. if the selected month is 4, it would become 5);
        updateChoiceMonth(false);
    }


    // ------private functions------
    // helper function for rotating the wheel
    void rotateWheel(GameObject wheel, float choices)
    {
        // process number of degrees to get from one choice to another on a wheel
        float turnDegree = 360f / choices;

        // turn the wheel
        wheel.transform.Rotate(new Vector3(0, 0, turnDegree));

    }

    // helper function for updating the user's choices
    void updateChoiceMonth(bool reverse)
    {
        // basically update the current choice to be the choice before/after it on the wheel

        // going in reverse (counting sequentially downwards: 3, 2, 1, ...)
        if (reverse)
        {
            // reset to the end if the end of the wheel's choices are reached (since the choices are circular)
            if (userChoiceMonth - 1 < 1)
            {
                userChoiceMonth = monthChoices;
            }
            else
            {
                userChoiceMonth--;
            }
        }

        // going forward (counting sequentially upwards: 1, 2, 3, ...)
        else
        {
            // reset to the start if the end of the wheel's choices are reached (since the choices are circular)
            if (userChoiceMonth + 1 > monthChoices)
            {
                userChoiceMonth = 1;
            }
            else
            {
                userChoiceMonth++;
            }
        }

        // update image corresponding to chosen month
        updateImageMonth(userChoiceMonth);

        Debug.Log("MONTH: " + userChoiceMonth);
    }

    // helper function for updating the user's choices
    void updateChoiceDay(bool reverse)
    {
        // basically update the current choice to be the choice before/after it on the wheel

        // going forward (counting sequentially upwards: 1, 2, 3, ...)
        if (reverse)
        {
            // reset to the start if the end of the wheel's choices are reached (since the choices are circular)
            if (userChoiceDay + 1 > dayChoices - 1)
            {
                userChoiceDay = 0;
            }
            else
            {
                userChoiceDay++;
            }
        }

        // going in reverse (counting sequentially downwards: 3, 2, 1, ...)
        else
        {
            // reset to the end if the end of the wheel's choices are reached (since the choices are circular)
            if (userChoiceDay - 1 < 0)
            {
                userChoiceDay = dayChoices - 1;
            }
            else
            {
                userChoiceDay--;
            }
        }

        // update image corresponding to chosen day
        updateImageDay(userChoiceDay);

        Debug.Log("DAY: " + userChoiceDay);
    }

    // helper function for updating image for DAY (works slightly different from month since it counts from 0)
    void updateImageDay(int choice)
    {
        dayImageObject.GetComponent<Image>().sprite = daySprites[choice];
    }

    // helper function for updating image for MONTH
    void updateImageMonth(int choice)
    {
        monthImageObject.GetComponent<Image>().sprite = monthSprites[choice - 1];
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
        puzzleStorage.GetComponent<FloorCompletion>().updateFloorTwoPuzzlesCompleted();
        Debug.Log("PUZZLE COMPLETE");
    }

}
