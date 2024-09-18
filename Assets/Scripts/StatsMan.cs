using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMan : MonoBehaviour
{
    public Text scoreText; // Arraste o Text da UI para esse campo no inspector

    void Start()
    {
        // Carrega a pontuação do PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("MiniGameScore", 0); // Padrão é 0 se não houver pontuação salva

        // Atualiza o texto na UI com a pontuação final
        scoreText.text = "Pontuação Final: " + finalScore.ToString();
    }
}
