using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
namespace Platformer 
{ 
    public class PlayerController : MonoBehaviour 
    { 
        public float movingSpeed;         
        public float jumpForce;         
        private float moveInput; 
        private bool facingRight = false; 
        private bool isGrounded;         
        public Transform groundCheck; 
        private Rigidbody2D rb;         
        private Animator animator;
        private bool canDoubleJump = true; 
        public int maxHealth = 100;
	    public int currentHealth;
	    public HealthBar healthBar;
        public GameObject pauseScreen;
        public bool isPaused;
        [SerializeField] private AudioSource jumpSoundEffect;
        [SerializeField] private AudioSource playerHurtSoundEffect;
        
 
 
        // Start is called before the first frame update         
        void Start() 
        { 
            rb = GetComponent<Rigidbody2D>();             
            animator = GetComponent<Animator>(); 

            currentHealth = maxHealth;
		    healthBar.SetMaxHealth(maxHealth);
        } 
 
        private void FixedUpdate() 
        { 
            CheckGround(); 
        } 
 
        // Update is called once per frame         
        void Update()
        { 
            if (Input.GetButton("Horizontal")) 
            { 
                moveInput = Input.GetAxis("Horizontal"); 
                Vector3 direction = transform.right * moveInput;
                 
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime); 
                animator.SetInteger("playerState", 1); // Turn on run animation

                
            }             
            else             { 
                if (isGrounded) animator.SetInteger("playerState", 0); //Turn on idle animation 
               
            } 
            if (Input.GetKeyDown(KeyCode.Space)) 
    { 
        if (isGrounded)
        {
            jumpSoundEffect.Play();
            // Regular jump
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse); 
            canDoubleJump = true; // Reset double jump ability
        }
        else if (canDoubleJump)
        {   
            jumpSoundEffect.Play();
            // Double jump
            rb.velocity = new Vector2(rb.velocity.x, 0); // Reset vertical velocity
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse); 
            canDoubleJump = false; // Disable double jump until grounded again
        }
    }
            if (!isGrounded)animator.SetInteger("playerState", 2); //Turn on jump animation 
 
            if(facingRight == false && moveInput < 0) 
            { 
                Flip(); 
            } 
            else if(facingRight == true && moveInput > 0) 
            { 
                Flip(); 
            }         
        } 
        private void Flip() 
        { 
            facingRight = !facingRight; 
            Vector3 Scaler = transform.localScale;             
            Scaler.x *= -1; 
            transform.localScale = Scaler; 
        } 
        private void CheckGround() 
        { 
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);             isGrounded = colliders.Length > 1; 
        } 


        void TakeDamage(int damage)
	    {
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            
            if (other.gameObject.tag == "Fall")
            {
                Debug.Log("Fall detected");
                gameObject.SetActive(true);
                PauseUnpause();
            }

            if (other.gameObject.tag == "Enemy")
            {
                
                if (currentHealth > 0)
                {
                    playerHurtSoundEffect.Play();
                    currentHealth -= 10;
                    healthBar.SetHealth(currentHealth);
                }

                if (currentHealth ==0)
                {
                    gameObject.SetActive(true);
                    PauseUnpause();
                }

            }
        }


    } 
} 
