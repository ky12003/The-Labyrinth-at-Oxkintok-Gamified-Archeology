using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showmenu : MonoBehaviour
{
     // Assign in inspector
    private bool isShowing;
    private GameObject Menu;
    void hide()
    {
        gameObject.SetActive(false);

    }

    void update()
    {
        gameObject.SetActive(false);
    }
    

    void show()
    {
        

        
        
             gameObject.SetActive(true);//If so, then activate it
         
    }
}
