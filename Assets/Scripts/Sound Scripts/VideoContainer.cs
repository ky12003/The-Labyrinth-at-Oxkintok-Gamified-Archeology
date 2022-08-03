using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoContainer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject videocontainer;
    public AudioSource skipsound;

    public void skipvideo()
    {
        if(PlaySound.getOn())
         skipsound.Play();
    }

}
