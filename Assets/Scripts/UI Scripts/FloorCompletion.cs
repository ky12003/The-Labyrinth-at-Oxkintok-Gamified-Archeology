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
    public AudioClip completionSound; // sound for floor completion

    void Start()
    {
        if (OnFloor2Completion == null)
            OnFloor2Completion = new UnityEvent();
    }

    // update the number of completed puzzles/handle floor completion
    public void updateFloorTwoPuzzlesCompleted()
    {
        puzzlesCompletedF2++;
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
