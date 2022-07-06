using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaySound : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
   bool On=true;
   public static AudioSource aud;

    public void playSound()
    {
        On = !On;
        aud = GetComponent<AudioSource>();


        if (On)
        {
            aud.Play();
        }
        else aud.Stop();




    }
}
