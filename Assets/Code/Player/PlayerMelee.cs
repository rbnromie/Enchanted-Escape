using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public Transform attackOrigin;
    public float attackRadius = 1f;
    public LayerMask enemyMask;

    public float cooldownTime = .5f;
    private float cooldownTimer = 0f;

    public int attackDamage = 20;

    public Animator animator;



    private void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Input.GetKey(KeyCode.J))
            {
                //Example of playing attack animation
                animator.SetTrigger("Attack");

                Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, enemyMask);
                foreach (var enemy in enemiesInRange)
                {   
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                    //enemy.GetComponent<HealthManager>().TakeDamage(attackDamage, transform.position);
                }

                cooldownTimer = cooldownTime;
            }
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackOrigin.position, attackRadius);
    }
}