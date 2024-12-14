using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoodCollect : MonoBehaviour
{
    
    private int point = 0;
    public int nextLevelpoint;
    public string nextLevel;

    [SerializeField] private Text pointText;
    [SerializeField] private AudioSource collectSoundEffect; 
    [SerializeField] private GameObject finishPanel,gameOverPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            point ++;
            pointText.text = "X "+point;
        }

        if (collision.gameObject.CompareTag("Exit"))
        {
            if(point == nextLevelpoint)
            {
                finishPanel.SetActive(true);
            }
            else
            {
                gameOverPanel.SetActive(true);
            }
        }

    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene(nextLevel);
    }
}