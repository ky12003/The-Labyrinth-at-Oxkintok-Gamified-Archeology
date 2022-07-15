using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Audio;

public class PlaySound : MonoBehaviour
{
    static public bool On=true; // boolean for enabling/disabling volume
    static public float lastVol = 0;// last volume before pressing mute button
    public AudioMixer audioMixer;

    public void playSound()
    {
        
        On = !On; // toggle for mute/unmute
        
        if (On)
        {
            audioMixer.SetFloat("MusicVol", lastVol);
            // GetComponent<AudioSource>().Play();
            
        }
        else 
        {
            // store last volume setting
            audioMixer.GetFloat("MusicVol", out lastVol);
            audioMixer.SetFloat("MusicVol", -80);
            // GetComponent<AudioSource>().Stop();
            
        }




    }

    private void Update() {
        Debug.Log(On);

    }
}