using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("StartStory");
    }

    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Level3()
    {
         SceneManager.LoadScene("Level3");
    }

     public void Level2()
    {
         SceneManager.LoadScene("Level 2");
    }
}
