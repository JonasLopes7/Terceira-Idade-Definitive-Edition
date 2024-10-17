using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMan : MonoBehaviour
{
    public Text highScoreText;  // Arraste o componente Text para este campo no Inspector

    void Start()
    {
        // Puxa o high score salvo no PlayerPrefs
        int highScore = PlayerPrefs.GetInt("HighScoreCard", 0);

        // Exibe o high score no Text UI
        highScoreText.text = "High Score: " + highScore;
    }
}
