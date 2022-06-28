using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showmenu : MonoBehaviour
{
    public GameObject Menu; // Assign in inspector
    private bool isShowing;

    void Update()
    {
       
            
            Menu.SetActive(true);
        
    }
}
