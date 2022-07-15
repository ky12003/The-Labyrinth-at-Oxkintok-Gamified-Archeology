using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookUI : MonoBehaviour
{
    /*----
    VARIABLES
    ----*/
    //-----serialized variables-----
    [SerializeField] GameObject turnNextPageButton;
    [SerializeField] GameObject turnPrevPageButton;

    //-----public variables-----
    public GameObject[] pageObjects; // game objects representing each page in the notebook

    //-----private variables-----
    static int currPage = 1; // stores current page that the user is on 
    static int numPages = 1; // stores the number of pages in the notebook

    /*----
    METHODS
    ----*/
    //-----unity methods-----
    void Update() {
        // for updating the "next" button (set active if there is an available page after the current page)
        if (currPage+1 <= numPages) {
            turnNextPageButton.SetActive(true);
        } else {
            turnNextPageButton.SetActive(false);
        }

        // for updating the "previous" button (set active if there is an available page before the current page)
        if (currPage-1 >= 1) {
            turnPrevPageButton.SetActive(true);
        } else {
            turnPrevPageButton.SetActive(false);
        }
    }

    //-----public class methods-----
    // set the number of pages available in the notebook
    public void updateNumPages() {
        numPages++;
    }

    // turn to the next page
    public void turnToNextPage() {
        pageObjects[currPage-1].SetActive(false);
        pageObjects[currPage].SetActive(true);
        currPage++;
    }

    // turn to the previous page
    public void turnToPrevPage() {
        pageObjects[currPage-1].SetActive(false);
        pageObjects[currPage-2].SetActive(true);
        currPage--;
    }

    //-----private class methods-----

}
