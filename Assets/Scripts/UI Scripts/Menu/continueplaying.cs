using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class continueplaying : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu;
    public GameObject play;
    public GameObject instructions;
    public Camera c;
    int active = 0;
    
    

    public void playing()
    {
        showing(1);


    }

    public void showinstructions()
    {
        showing(2);
    }



    void showing(int i)
    {
        GameObject[] g = new GameObject[5];
        g[0] = Menu;
        g[1] = play;
        g[2] = instructions;
        g[active].SetActive(false);
        g[i].SetActive(true);
        active = i;



    }

    public void backtomenu()
    {
        showing(0);
    }






    // Update is called once per frame
}
