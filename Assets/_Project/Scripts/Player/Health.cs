using UnityEngine;
using UnityEngine.Events;

namespace PixDash.Player
{
    public class Health : MonoBehaviour
    {
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead = false;

        public UnityEvent<int> onHealthChanged = new UnityEvent<int>();
        public UnityEvent onDeath = new UnityEvent();

    private void Start()
    {
        currentHealth = maxHealth;
        onHealthChanged?.Invoke(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log($"<color=red>Player took {amount} damage!</color> Current Health: {currentHealth}");
        onHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            Debug.Log($"<color=black><b>{gameObject.name} has died!</b></color>");
            onDeath?.Invoke();
        }
    }
}
