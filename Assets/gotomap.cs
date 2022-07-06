using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotomap : MonoBehaviour
{
    public GameObject player3d;
    public GameObject map;
    void OnGUI()
    {


        if (Input.GetKeyDown(KeyCode.M))
        {
            player3d.SetActive(false);
            map.SetActive(true);
        }
    }
}
