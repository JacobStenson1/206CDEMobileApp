using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public GameObject homePage;
    public GameObject loginPage;
    public GameObject attendancePage;
    public GameObject reportLostStickerPage;

    TextMeshProUGUI usernameEntered;
    TextMeshProUGUI passwordEntered;

    public GameObject buttonsParent;

    public string usernameEnteredText;
    public string passwordEnteredText;

    GameObject currentGameObject;
    bool loginCreds;

    public string[] users;
    string thisFirstName;
    string thisSurname;
    string thisCourse;
    string thisSsid;
    string thisClassId;

    int UserNumber;

    TextMeshProUGUI NameText;
    TextMeshProUGUI CourseText;
    TextMeshProUGUI SSIDText;

    Transform nameObject;
    Transform courseObject;
    Transform ssidObject;


    // - - //


    // Start is called before the first frame update
    void Start()
    {
        // Turns off the buttons on app start
        buttonsParent.SetActive(false);
        //Sets the current gameobject to be the login page.
        currentGameObject = loginPage;

        StartCoroutine(LoadData());
    }

    // Check to see if the user's credentials are correct
    public void Login()
    {
        loginCreds = true;

        GetEnteredData();


        // If the users entered stuff is right then...
        if (loginCreds == true)
        {
            currentGameObject.SetActive(false);
            homePage.SetActive(true);
            currentGameObject = homePage;

            buttonsParent.SetActive(true);
        }
        
    }

    void GetEnteredData()
    {
        Transform usernameObject;
        Transform passwordObject;

        usernameObject = loginPage.transform.Find("Info/EnterUsername");
        passwordObject = loginPage.transform.Find("Info/EnterPassword");

        usernameEnteredText = usernameObject.GetComponent<TMP_InputField>().text;
        passwordEnteredText = passwordObject.GetComponent<TMP_InputField>().text;
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

    IEnumerator LoadData()
    {
        WWW userData = new WWW("http://localhost/realworldproject/userdata.php");
        yield return userData;

        string userDataString = userData.text;

        Debug.Log(userDataString);
        users = userDataString.Split(';');
        
        Debug.Log(GetThisUserData(users[0], "Class_ID:"));

        //Cycle through the users till you find the user with the same username as the login.

        UserNumber = 0;

        thisFirstName = GetThisUserData(users[UserNumber], "First name:");
        thisSsid = GetThisUserData(users[UserNumber], "SSID:");
        thisCourse = GetThisUserData(users[UserNumber], "Course:");
        thisClassId = GetThisUserData(users[UserNumber], "Class_ID:");

        //Debug.Log(thisFirstName + thisSsid + thisCourse + thisClassId);

        SetText(thisFirstName, thisCourse, thisSsid);

    }

    string GetThisUserData(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index)+index.Length);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }



    void SetText(string name, string course, string ssid)
    {
        nameObject = homePage.transform.Find("Info/Name");
        courseObject = homePage.transform.Find("Info/Course");
        ssidObject = homePage.transform.Find("Info/SSID");

        NameText = nameObject.GetComponent<TextMeshProUGUI>();
        CourseText = courseObject.GetComponent<TextMeshProUGUI>();
        SSIDText = ssidObject.GetComponent<TextMeshProUGUI>();

        NameText.text = "Hi " + name;
        CourseText.text = course;
        SSIDText.text = "SSID: " + ssid;

    }
}
