using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorCompletion : MonoBehaviour
{
    // events
    public UnityEvent OnFloor2Completion; // event for floor completion

    // stuff for checking if a floor is completed
    int puzzlesCompletedF2 = 0;

    // misc
    public GameObject player; // object for player
    public GameObject notificationPopupObject; // object for notification popups
    public AudioClip completionSound; // sound for floor completion
    public Material indicatorMaterial; // material for updating the indicator for if a puzzle is complete

    //void Start()
    //{
    //    if (OnFloor2Completion == null)
    //        OnFloor2Completion = new UnityEvent();
    //}

    // update the number of completed puzzles/handle floor completion
    public void updateFloorTwoPuzzlesCompleted(GameObject indicatorOne, GameObject indicatorTwo)
    {
        // update number of puzzles completed
        puzzlesCompletedF2++;
        // give a notification popup of how many puzzles are completed, then update the indicators
        notificationPopupObject.GetComponent<NotificationPopup>().activateNotif("Completed: " + puzzlesCompletedF2 + "/5 puzzles.");
        // used source: https://answers.unity.com/questions/59355/change-the-material-on-an-object-in-a-script.html
        indicatorOne.GetComponent<MeshRenderer>().material = indicatorMaterial;
        indicatorTwo.GetComponent<MeshRenderer>().material = indicatorMaterial;

        // if all puzzles on floor 2 are completed, handle the completion
        if (puzzlesCompletedF2 == 5)
        {
            OnFloor2Completion.Invoke();
            player.GetComponent<AudioSource>().PlayOneShot(completionSound, 0.5f);
        }
    }

    

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
