using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointMan : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    private int score = 0;
    private int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScoreClock", 0);
        highScoreText.text = "High Score: " + highScore;

        scoreText.text = "Score: " + score;
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore;
            PlayerPrefs.SetInt("HighScoreClock", highScore);
            PlayerPrefs.Save();
        }
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }
}
