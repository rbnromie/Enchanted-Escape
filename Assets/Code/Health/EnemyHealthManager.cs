using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            TakeDamage(20);
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        healthBar.SetCurrentHealth(currentHealth);
    }
}