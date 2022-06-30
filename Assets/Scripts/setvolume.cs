using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class setvolume : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer am;
    public void setVolume(float v){ am.SetFloat("volume", Mathf.Log10(v)*20); }

}
