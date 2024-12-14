using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel1 : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 50;
    int currentHealth;
    [SerializeField] private AudioSource HurtEffet;
    [SerializeField] private AudioSource DiedEffet;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play hurt animation
        animator.SetTrigger("Hurt");
        HurtEffet.Play();


        if (currentHealth <= 0)
        {
            DiedEffet.Play();
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        // Die animation
        animator.SetBool("IsDead", true);

        // Disable the enemy
        GetComponent<Collider2D>().isTrigger = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

        this.enabled = false;
        Destroy(gameObject,2.0f);

    }
}