using UnityEngine;
namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField]float health;
        Animator animator;

        bool isDead;

        public bool IsDead()
        {
            return isDead;
        }
        
        private void Awake() {
            animator = GetComponent<Animator>();
            isDead = false;
        }

        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            Die();
        }

        private void Die()
        {
            if (health == 0 && !isDead)
            {
                isDead = true;
                animator.SetTrigger("die");
            }
        }
    }
}