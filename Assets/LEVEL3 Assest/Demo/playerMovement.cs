using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerMovement : MonoBehaviour
{
    float moveInput;
    public Rigidbody2D rb;
    public float speed;
    public Transform pos;
    public float radius;
    public LayerMask groundLayers;
    public float jumpforce;
    public float heightCutter;
    bool grounded;
  

    private int life = 3;
    private float hurtForce = 8f;
    [SerializeField] private Text lifeText;
    public ParticleSystem deathPlayer;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource hurtSoundEffect;

    public static playerMovement instance;
    public GameObject pauseScreen;
    public bool isPaused;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        instance = this;
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0f)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (moveInput < 0f)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
   
        grounded = Physics2D.OverlapCircle(pos.position, radius, groundLayers);
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpSoundEffect.Play();
            rb.velocity = Vector2.up * jumpforce;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * heightCutter);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (life > 0)
            {
                hurtSoundEffect.Play();
                life -= 1;
                lifeText.text = "Life: " +life;
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
                if (life == 0)
                {

                    deathSoundEffect.Play();
                    Instantiate(deathPlayer, transform.position, Quaternion.identity);
                    gameObject.SetActive(false);
                    PauseUnpause();
                }
            }
        }
        if (other.gameObject.tag == "Fall")
        {
            deathSoundEffect.Play();
            Instantiate(deathPlayer, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
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
        
    

