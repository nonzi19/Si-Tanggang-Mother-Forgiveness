using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelComplete : MonoBehaviour
{
    public static LevelComplete instance;
    public GameObject pauseScreen;
    public bool isPaused;
    [SerializeField] private AudioSource CompleteEffect;
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

    }  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
        {
            CompleteEffect.Play();
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
    public void NextLevel()
    {
        SceneManager.LoadScene("Level 4");
        Time.timeScale = 1f;
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1f;
    }
}
