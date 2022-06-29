using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Option : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource m_MyAudioSource;
    //Value from the slider, and it converts to volume level
    
    public float volume;

    

   

    public void Menu()
    {

        SceneManager.LoadScene(0);

    }
}
