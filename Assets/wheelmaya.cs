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
    string[] s = new string[] {"s","move"};
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
        
        an.transform.Rotate(new Vector3(0, 0, 30));
       // Random rnd = new Random();

        for (int j = 0; j < s.Length; j++)
        {
            an.Play(s[j]);
            //Debug.Log(j); // returns random integers >= 10 and < 19
        }
        

    }
   
}
