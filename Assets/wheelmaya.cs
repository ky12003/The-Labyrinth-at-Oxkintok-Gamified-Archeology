using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wheelmaya : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rul;
    public Animation an;
    string[] s = new string[] {"s"};
    float rotationSpeed = 45;
    Vector3 currentEulerAngles;
    Quaternion currentRotation;
    float x;
    float y;
    float z;
    public void rotateleft()
    {
        //
        /*  for (int i=0; i < s.Length;i++)
        

    }*/
        an.Play(s[0]);
        an.transform.Rotate(new Vector3(0, 0, 30));


    }
   
}
