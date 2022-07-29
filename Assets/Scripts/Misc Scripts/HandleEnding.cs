using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HandleEnding : MonoBehaviour
{
    /*

    VARIABLES

    */
    // -- public variables --
    public GameObject VideoOutputObject; // the player for the video
    public GameObject EndingUIContainer; // where stuff pertaining to the ending are displayed in the UI
    public GameObject MainPlayerUI;
    //public UnityEvent OnVideoEnd;

    /*

    FUNCTIONS

    */

    // -- public functions --

    // -- private functions -- 
    void StartEndingSequence()
    {
        // activate the video
        EndingUIContainer.SetActive(true);
        VideoOutputObject.SetActive(true);
        MainPlayerUI.SetActive(false);

        var videoPlayer = VideoOutputObject.GetComponent<VideoPlayer>();


        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        //OnVideoEnd.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // -- unity functions -- 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartEndingSequence();
        }
        
    }
}
