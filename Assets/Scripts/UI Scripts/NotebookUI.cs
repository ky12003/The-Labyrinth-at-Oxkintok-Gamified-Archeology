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
    static int totPages = 6; // the total number of possible pages in the notebook
    static int newNextPage; // for storing next page
    static int newPrevPage; // for storing previous page
    static bool[] pagesActive = new bool[totPages]; // array of booleans; position denotes which pages are available

    /*----
    METHODS
    ----*/
    //-----unity methods-----

    void Update() {
        newNextPage = availablePage("front");
        newPrevPage = availablePage("back");

        // for updating the "next" button (set active if there is an available page after the current page)
        if (newNextPage != currPage) {
            turnNextPageButton.SetActive(true);
        } else {
            turnNextPageButton.SetActive(false);
        }

        // for updating the "previous" button (set active if there is an available page before the current page)
        if (newPrevPage != currPage) {
            turnPrevPageButton.SetActive(true);
        } else {
            turnPrevPageButton.SetActive(false);
        }
    }

    //-----public class methods-----
    // update the notebook pages
    public void updateNotebook(int pageNum) {
        // activate page corresponding to page part if the page is not already made available
        if (pagesActive[pageNum-1] == false)
        {
            pagesActive[pageNum-1] = true;
        }
        
    }

    // turn to the next page
    public void turnToNextPage() {
        pageObjects[currPage-1].SetActive(false);
        pageObjects[newNextPage-1].SetActive(true);
        currPage = newNextPage;
    }

    // turn to the previous page
    public void turnToPrevPage() {
        pageObjects[currPage-1].SetActive(false);
        pageObjects[newPrevPage-1].SetActive(true);
        currPage = newPrevPage;
    }

    // initialize the boolean array for the pages
    public void initializeArr()
    {
        pagesActive[0] = true;
        for (int i = 1; i < totPages; i++)
        {
            pagesActive[i] = false;
        }
    }

    //-----private class methods-----
    // check if a page is available (returns the current page if it's not, returns the next/previous page number if there is a page available)
    public int availablePage(string position)
    {
        int currentPage = currPage; // store temporary variable for the current page (since it will be updated when checking for an available page

        // check for page after current page
        if (position == "front")
        {
            currentPage++;
            // check if a page after the current page is available
            while (currentPage <= totPages)
            {
                if (pagesActive[currentPage - 1])
                {
                    // a page after the current page has been found
                    return currentPage;
                }
                currentPage++;
            }
            // no new pages after the current page has been found
            return currPage;
        } 
        // check for page before current page
        else if (position == "back")
        {
            currentPage--;
            // check if a page after the current page is available
            while (currentPage >= 1)
            {
                if (pagesActive[currentPage - 1])
                {
                    // a page before the current page has been found
                    return currentPage;
                }
                currentPage--;
            }
            // no new pages after the current page has been found
            return currPage;
        }
        else
        {
            return -1; // invalid input
        }
    }
}
