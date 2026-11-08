using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverText;
    public GameObject winText;
    public GameObject restartButton;

    public bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;
        gameEnded = false;

        gameOverText.SetActive(false);
        winText.SetActive(false);
        restartButton.SetActive(false);

        UpdateScoreText();
    }

    public void AddPoint()
    {
        if (gameEnded)
            return;

        score++;
        UpdateScoreText();

        if (score >= 10)
        {
            WinGame();
        }
    }

    public void BeginGameOver()
    {
        gameEnded = true;
    }

    public void FinishGameOver()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);

        Time.timeScale = 0f;
    }

    void WinGame()
    {
        if (gameEnded)
            return;

        gameEnded = true;

        winText.SetActive(true);
        restartButton.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Pont: " + score;
    }
}