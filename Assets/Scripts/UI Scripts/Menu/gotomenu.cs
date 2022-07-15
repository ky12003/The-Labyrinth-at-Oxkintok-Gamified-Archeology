using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotomenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject canvmen;
    public GameObject Playing;

    void OnGUI()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            canvmen.SetActive(true);
            Menu.SetActive(true);
            Playing.SetActive(false);
        }
    }
}
