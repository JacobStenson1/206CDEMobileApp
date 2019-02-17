using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject homePage;
    public GameObject loginPage;
    public GameObject attendancePage;
    public GameObject reportLostStickerPage;

    public GameObject buttonsParent;

    GameObject currentGameObject;
    bool loginCreds;


    // - - //


    // Start is called before the first frame update
    void Start()
    {
        // Turns off the buttons on game start
        buttonsParent.SetActive(false);
        currentGameObject = loginPage;
    }

    // Check to see if the user's credentials are correct
    public void Login()
    {
        loginCreds = true;


        // If the users entered stuff is right then...
        if (loginCreds == true)
        {
            currentGameObject.SetActive(false);
            homePage.SetActive(true);
            currentGameObject = homePage;

            buttonsParent.SetActive(true);
        }
        
    }

    public void HomepageButton()
    {
        // Turns off the current gameobject and turns on the homepage one.

        currentGameObject.SetActive(false);
        homePage.SetActive(true);
        currentGameObject = homePage;
    }

    public void AttendanceButton()
    {
        // Turns off the current gameobject and turns on the attendance one.

        currentGameObject.SetActive(false);
        attendancePage.SetActive(true);
        currentGameObject = attendancePage;
    }

    public void ReportLostStickerButton()
    {
        // Turns off the current gameobject and turns on the report lost sticker one.

        currentGameObject.SetActive(false);
        reportLostStickerPage.SetActive(true);
        currentGameObject = reportLostStickerPage;
    }
}
