using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class changepagesound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource soundpage, soundpageback, mouseonpage;
    public void playthesound() {
        if(PlaySound.getOn())
            soundpage.Play();
    }

    public void rewindpage()
    {
        if (PlaySound.getOn())
            soundpageback.Play();
    }

   
}
