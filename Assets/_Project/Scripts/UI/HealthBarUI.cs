using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using PixDash.Player;

namespace PixDash.UI
{
    public class HealthBarUI : MonoBehaviour
    {
        public Health health;
        public Image fillImage;
        public TextMeshProUGUI healthText;

        private void Start()
        {
            if (health != null)
            {
                health.onHealthChanged.AddListener(UpdateHealthBar);
                UpdateHealthBar(health.currentHealth);
            }
        }

        private void UpdateHealthBar(int currentHealth)
        {
            if (fillImage != null && health != null)
            {
                float fillAmount = (float)currentHealth / health.maxHealth;
                fillImage.fillAmount = fillAmount;
            }

            if (healthText != null && health != null)
            {
                healthText.text = $"{currentHealth} / {health.maxHealth}";
            }
        }

        private void OnDestroy()
        {
            if (health != null)
            {
                health.onHealthChanged.RemoveListener(UpdateHealthBar);
            }
        }
    }
}
