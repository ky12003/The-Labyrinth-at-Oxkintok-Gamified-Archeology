using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class changepagesound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource soundpage, soundpageback;
    public void playthesound() {
        if(PlaySound.getOn())
            soundpage.Play();
    }

    public void playsoundback()
    {
        if(PlaySound.getOn())
            soundpageback.Play();
    }
}