using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string _levelToLoad;
    public void Play ()
    {
        SceneManager.LoadScene(_levelToLoad);

    }

 
    public void Quit ()
    {
        Debug.Log("Exiting .....");
        Application.Quit();
    }
}
