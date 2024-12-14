using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu instance;
    public GameObject pauseScreen;
    public bool isPaused;
    private int life = 3;
    [SerializeField] private Text lifeText;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
 
    }
    // Update is called once per frame
    void Update()
    {
        if (life == 0)
                {
                    PauseUnpause();
                }
    }
    public void PauseUnpause()
    {
        if(isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        } else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    

    public void GameOver()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1f;
    }
}