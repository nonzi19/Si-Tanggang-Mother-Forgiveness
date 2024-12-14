using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyCollect : MonoBehaviour
{
    
    private int point = 0;
    public int nextLevelpoint;
    public string nextLevel;
    [SerializeField] private GameObject finishPanel,gameoverPanel;
    [SerializeField] private Text pointText;
    [SerializeField] private AudioSource collectSoundEffect; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Money"))
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
                gameoverPanel.SetActive(true);
            }
        }

    }
    
    public void OnButtonClick()
    {
        SceneManager.LoadScene(nextLevel);
    }


}
