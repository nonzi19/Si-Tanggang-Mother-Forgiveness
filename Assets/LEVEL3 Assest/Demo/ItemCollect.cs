using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ItemCollect : MonoBehaviour
{
    private int point = 0;
 
    [SerializeField] private Text pointText;
    [SerializeField] private AudioSource collectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Reward"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            point ++;
            pointText.text = "Point: " + point;
        }
    }
    
}