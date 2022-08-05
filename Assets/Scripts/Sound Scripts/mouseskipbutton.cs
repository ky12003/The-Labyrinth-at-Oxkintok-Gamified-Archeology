using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseskipbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource SoundSkip;
    public void mouseonskip()
    {
        SoundSkip.Play();
    }

}
