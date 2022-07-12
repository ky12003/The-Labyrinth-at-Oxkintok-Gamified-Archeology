using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookUI : MonoBehaviour
{
    /*----
    VARIABLES
    ----*/
    //-----serialized variables-----

    //-----public variables-----
    public GameObject[] pageObjects; // game objects representing each page in the notebook

    //-----private variables-----
    static int currPage = 1; // stores current page that the user is on


    /*----
    METHODS
    ----*/
    //-----unity methods-----

    //-----public class methods-----

    // set the number of pages available in the notebook
    public void setNumPages(int numPages) {
        
    }

    //-----private class methods-----

}
