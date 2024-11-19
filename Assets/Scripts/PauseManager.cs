using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public AudioMixer audioMixer;
    private TimerScript timerScript;
    private float originalVolume = -20f;
    private float pauseVolume = -30f;

    void Start()
    {
        pausePanel.SetActive(false);
        timerScript = FindObjectOfType<TimerScript>();

        audioMixer.SetFloat("Musica", originalVolume);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        timerScript.timerIsRunning = false;

        audioMixer.SetFloat("Musica", pauseVolume);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        timerScript.timerIsRunning = true;

        audioMixer.SetFloat("Musica", originalVolume);
    }
}