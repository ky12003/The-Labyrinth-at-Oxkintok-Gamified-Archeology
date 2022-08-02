using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;



public class ShowMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu;
    public GameObject play;
    public GameObject instructions;
    public GameObject options;
    public GameObject credits;
    public GameObject mainsound;
    public TextMeshProUGUI playtext;
    public AudioSource audioData;

    int active=0;
   


    public void playing() {
        
        playtext.text = "Continue";
        showing(1);
        
        
    
    }

    public void showinstructions()
    {
        
        showing(2);
    }

    public void showoptions() { showing(3); }
    public void showcredits() { showing(4); }
    public void quit() { Application.Quit(); }



    void showing(int i) {
        GameObject[] g = new GameObject[5];
        g[0] = Menu;
        g[1] = play;
        g[2] = instructions;
        g[3] = options;
        g[4] = credits;
        if(PlaySound.getOn())
          audioData.Play();
         g[active].SetActive(false);
        g[i].SetActive(true);
        active = i;
       // soundbutton.SetActive(false);
        //  if (i != 0) { Menu.SetActive(false); }



    }

    public void backtomenu()
    {
        showing(0);
    }



}
