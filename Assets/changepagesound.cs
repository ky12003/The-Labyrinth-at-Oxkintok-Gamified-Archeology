using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class changepagesound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource soundpage, soundpageback;
    public void playthesound() {
        soundpage.Play();
    }

    public void playsoundback()
    {

        soundpageback.Play();
    }
}
