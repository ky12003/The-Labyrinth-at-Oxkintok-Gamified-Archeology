using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wheelmaya : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rul;
    
    
   
   
  
    float zleft=0f;
    float zright = 0f;
    bool upleft = true;
    bool upright = true;
    
    
    public void setpartitionleftup() { rotatewheel(zleft, upleft,19f); }
    public void setpartitionleftdown() { rotatewheel(zleft, upleft, -19f); }

    public void setpartitionrightup() { rotatewheel(zleft, upleft, -20f); }
    public void setpartitionrightdown() { rotatewheel(zleft, upleft, 20f); }


   
    float divide(float x)
    {
        return 360f/x;
    }

    void rotatewheel(float x,bool on,float z) {

        float s = divide(z);
       
        rul.transform.Rotate(new Vector3(0, 0, x + s)); }



   
   
}
