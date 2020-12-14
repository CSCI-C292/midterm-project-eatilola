using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningLevel : MonoBehaviour
{
    public string menuScene = "MainMenu";

    public string nextLevel;

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    // Start is called before the first frame update
    public void Menu()
    {
         SceneManager.LoadScene(menuScene);
    }
}
