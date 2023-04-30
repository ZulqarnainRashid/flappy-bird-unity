using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource scoreSFX;
    [SerializeField] TextMeshProUGUI highScoreText;


    void Start()
    {
        scoreSFX = GetComponent<AudioSource>();
        UpdateHighScoreText();
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        scoreSFX.Play();
        CheckHighScore();
    }

    public void CheckHighScore()
    {
        if(playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            UpdateHighScoreText();
        }
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);

/*        if(playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", playerScore);
            highScoreText.text = "High Score: " + highScore.ToString();
        }*/
    }
}
