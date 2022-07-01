using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotomenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Playing;

    void OnGUI()
    {


        if (Event.current.Equals(Event.KeyboardEvent("return")))
        {
            Menu.SetActive(true);
            
        }
    }
}
