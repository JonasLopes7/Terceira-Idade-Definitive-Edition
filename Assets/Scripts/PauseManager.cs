using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private TimerScript timerScript;

    void Start()
    {
        pausePanel.SetActive(false);
        timerScript = FindObjectOfType<TimerScript>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        timerScript.timerIsRunning = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        timerScript.timerIsRunning = true;
    }
}
