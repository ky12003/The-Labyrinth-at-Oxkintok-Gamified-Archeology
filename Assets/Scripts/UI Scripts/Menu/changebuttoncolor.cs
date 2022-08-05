using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class changebuttoncolor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btn;
 
    Color color;
    public void mouseenter()
    {
        //https://answers.unity.com/questions/1074381/how-to-attach-hover-event-to-button.html
        btn.GetComponent<Material>().SetColor("Blue Test", Color.black);
    }

    public void mouseout()
    {
        //https://answers.unity.com/questions/1074381/how-to-attach-hover-event-to-button.html
      //  btn.GetComponent<Material>().color = color;
        Debug.Log("mouse out");
    }
}
