    using Unity.VisualScripting;
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {   
        public Animator animator;
        public int maxHealth = 100;
        int currentHealth;

        void Start()
        {
       

                currentHealth = maxHealth;
   

        }

        public void TakeDamage(int damage)
        {   
            currentHealth -= damage;

            //Play hurt animation
            animator.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                Die();
                Destroy(gameObject);

            }

        }

        void Die()
        {
            Debug.Log("Enemy died!");
        //Die animation
        //animator.SetBool("IsDead" , true);
        //Disable enemey
        /*GetComponent<Collider2D>().enabled = false;
        this.enabled = false;*/
        

    }
}
