using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 60f; // Tempo inicial em segundos
    public Text timerText;            // Campo de UI para exibir o tempo
    public GameObject panel;          // Painel que aparecerá quando o tempo acabar

    private bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;
        panel.SetActive(false);       // Esconde o painel inicialmente
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                // Exibe apenas o valor numérico sem formatação
                timerText.text = Mathf.FloorToInt(timeRemaining).ToString();
            }
            else
            {
                // Quando o tempo acabar, o painel aparece
                timeRemaining = 0;
                timerIsRunning = false;
                panel.SetActive(true);
            }
        }
    }
}
