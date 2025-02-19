using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Image healthBar;
    public GameObject gameOverUI;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player dead！Game over");
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        Invoke("RestartGame", 3f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
