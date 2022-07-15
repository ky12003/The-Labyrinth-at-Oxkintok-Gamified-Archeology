using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[System.Serializable]
public class changetextcolor : MonoBehaviour
{
    
    public TextMeshProUGUI text;
    public Color col = Color.white;
    public Canvas can;

    void start()
    {
       
        
        
    }
    //https://forum.unity.com/threads/text-color-change-c.946824/

    public void changecolor()
    {

        
    }
    // Update is called once per frame
    void Update()
    {

        
        col = Color.yellow;
        text.color = col;
        text.text = "a";
        






    }
}
