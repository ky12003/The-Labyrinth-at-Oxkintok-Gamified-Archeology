using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitclose : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioData, mouseonexit;
    public void soundclose()
    {
        if(PlaySound.getOn())
          audioData.Play();
    }

    public void mouseover() { 
        
        
        if(PlaySound.getOn())
        mouseonexit.Play(); }
}
