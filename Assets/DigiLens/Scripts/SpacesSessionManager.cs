using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacesSessionManager : MonoBehaviour
{
    /// <summary> 
    /// Quits the app on application pause. The app must be closed to prevent 
    /// Qualcomm Spaces pause/resume issues. 
    /// </summary> 
    /// <param name="pause"></param> 
    void OnApplicationPause(bool pause)
    {
        if (pause) //On pause event, quit the application 
        {
            Application.Quit();
        }
    }

    /// <summary> 
    /// Quits the app when the scroll wheel is double clicked. 
    /// Scroll wheel double click is a global key event which returns 
    /// to the previous application. The app must be closed to prevent Qualcomm Spaces 
    /// pause/resume issues.
    /// </summary> 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //On scroll wheel double click, quit the application 
        {
            Debug.Log("back button");
            Application.Quit();
        }
    }
}
