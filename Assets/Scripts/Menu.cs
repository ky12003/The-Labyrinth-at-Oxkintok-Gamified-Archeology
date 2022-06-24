using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    private int index;
    public void Play()
    {
        index = 1;
        load();
       
    }

    public void Sound()
    {
        index = 2;
        load();

    }


    public void option()
    {
        index = 3;
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
}
