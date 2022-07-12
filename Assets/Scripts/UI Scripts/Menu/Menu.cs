using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    private int index;
    static public int test = 4;

    public void Play()
    {
        index = 1;
        load();
       
    }

    public void instructions()
    {
        index = 2;
        load();
    }


    public void option()
    {
        index = 3;
        load();
    }

    public void credits()
    {
        index = 4;
        load();
    }

    public void newPlayer()
    {
        index = 5;
        load();
    }



    public void Quit()
    {
        Application.Quit();
    }

    public void load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            test++;
        }
        Debug.Log(test);
    }
}
