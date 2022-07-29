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
    public GameObject VideoImageObject; // basically where the video plays within the UI canvas
    public UnityEvent OnVideoEnd;

    // -- private variables --
    bool introSkip = false;


    /*

    FUNCTIONS

    */

    // -- public functions --
    public void StartIntroSequence()
    {
        // activate the video
        VideoImageObject.SetActive(true);
        VideoOutputObject.SetActive(true);

        var videoPlayer = VideoOutputObject.GetComponent<VideoPlayer>();

        videoPlayer.loopPointReached += EndReached;
    }

    public void SkipIntro()
    {

    }

    // -- private functions -- 

    // -- unity functions --

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndReached(VideoPlayer vp)
    {
        Debug.Log("test");
        OnVideoEnd.Invoke();
    }
}
