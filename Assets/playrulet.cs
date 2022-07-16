using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playrulet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject rulleft;
  //  GameObjetc rulright;

   

    // Update is called once per frame
    

    void rotateleft()
    {
        rulleft.transform.Rotate(0, 0, 45f, Space.Self);
    }
}
