using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMan : MonoBehaviour
{
    public Text highScoreText;
    public Text highScoreClockText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScoreCard", 0);
        int highScoreClock = PlayerPrefs.GetInt("HighScoreClock", 0);

        highScoreClockText.text = "High Score Relogio: " + highScoreClock;
        highScoreText.text = "High Score Palavra: " + highScore;
    }
}
