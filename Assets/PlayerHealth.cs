using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Slider healthBar;

    public GameObject gameOverPanel;


    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Player died.");
        Time.timeScale = 0f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }



}
