using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointMan : MonoBehaviour
{
    private int score;
    public Text scoreText;

    void Start()
    {
        UpdateScoreText();
    }
    // Chame esta função quando o minigame terminar
    public void EndMiniGame()
    {
        // Salva a pontuação no PlayerPrefs
        PlayerPrefs.SetInt("MiniGameScore", score);
        // Salva as preferências
        PlayerPrefs.Save();

        // Carrega a cena da tela de stats
        UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
    }

    // Simulação de adicionar pontuação ao longo do minigame
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Pontuação: " + score.ToString();
    }
}
