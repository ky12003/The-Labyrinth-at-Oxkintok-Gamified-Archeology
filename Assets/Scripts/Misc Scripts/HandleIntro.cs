using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class HandleIntro : MonoBehaviour
{
    /*
     * for the intro (using guide: https://www.youtube.com/watch?v=p7iXEZGx2Mc AND documentation: https://docs.unity3d.com/ScriptReference/Video.VideoPlayer.html)
     */

    /*

    VARIABLES

    */
    // -- public variables --
    public GameObject VideoOutputObject; // the player for the video
    public GameObject IntroUIContainer; // where stuff pertaining to the intro are displayed in the UI
    public UnityEvent OnVideoEnd;

    // -- private variables --


    /*

    FUNCTIONS

    */

    // -- public functions --
    public void StartIntroSequence()
    {
        // activate the video
        IntroUIContainer.SetActive(true);
        VideoOutputObject.SetActive(true);

        var videoPlayer = VideoOutputObject.GetComponent<VideoPlayer>();


        videoPlayer.loopPointReached += EndReached;
    }

    public void SkipIntro(VideoPlayer vp)
    {
        EndReached(vp);
    }


    // -- private functions -- 
    void EndReached(VideoPlayer vp)
    {
        OnVideoEnd.Invoke();
    }

    // -- unity functions --

    // Update is called once per frame
    void Update()
    {
        
    }


}
