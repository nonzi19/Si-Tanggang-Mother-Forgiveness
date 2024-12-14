using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public static StartMenu instance;

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
      

    public void StartLevel()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1f;
    }
}
