using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float knockbackForce = 5f;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    [SerializeField] private AudioSource AttackSoundEffect;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown("e"))
            {
                AttackSoundEffect.Play();
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyLevel1 enemyScript = enemy.GetComponent<EnemyLevel1>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackDamage);
                ApplyKnockback(enemy.transform);
            }
        }
    }

    void ApplyKnockback(Transform enemyTransform)
    {
        Vector2 knockbackDirection = (enemyTransform.position - transform.position).normalized;
        enemyTransform.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
