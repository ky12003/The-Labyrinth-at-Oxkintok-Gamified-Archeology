using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageUpdate : MonoBehaviour
{
    /*----
    VARIABLES
    ----*/
    //-----serialized variables-----

    //-----public variables-----
    public GameObject[] pageParts; // game objects representing each part of a page in the notebook

    //-----private variables-----
    static int currPart = 0; // stores current page that the user is on

    /*----
    METHODS
    ----*/
    //-----unity methods-----

    //-----public class methods-----

    // update the part of the page that should be loaded (for this page, parts range from 0 to 6)
    public void updatePart(int partNum) {
        pageParts[partNum].SetActive(true);
    }

    //-----private class methods-----
}
