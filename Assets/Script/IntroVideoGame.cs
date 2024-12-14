using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideoGame : MonoBehaviour
{
    public void NextGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
