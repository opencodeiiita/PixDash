using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image fillImage;
    public Text healthText;

    private void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.onHealthChanged.AddListener(UpdateHealthBar);
            UpdateHealthBar(playerHealth.currentHealth);
        }
    }

    private void UpdateHealthBar(int currentHealth)
    {
        if (fillImage != null)
        {
            float fillAmount = (float)currentHealth / playerHealth.maxHealth;
            fillImage.fillAmount = fillAmount;
        }

        if (healthText != null)
        {
            healthText.text = $"{currentHealth} / {playerHealth.maxHealth}";
        }
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.onHealthChanged.RemoveListener(UpdateHealthBar);
        }
    }
}
