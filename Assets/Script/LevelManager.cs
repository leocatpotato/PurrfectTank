using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject victoryPanel;

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            gameEnded = true;
            ShowVictory();
        }
    }

    void ShowVictory()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
