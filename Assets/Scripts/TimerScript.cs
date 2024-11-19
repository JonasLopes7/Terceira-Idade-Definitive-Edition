using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 60f;
    public Text timerText;
    public Text countdownText;
    public GameObject panel;
    public GameObject panelCountdown;

    public bool timerIsRunning = false;
    private bool countdownFinished = false;
    public GameObject dica;

    public AudioMixer audioMixer;
    private float originalVolume = -30f;

    void Start()
    {
        panel.SetActive(false);

        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (countdownFinished && timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = Mathf.FloorToInt(timeRemaining).ToString();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                panel.SetActive(true);
                audioMixer.SetFloat("Musica", originalVolume);
            }
        }
    }

    IEnumerator StartCountdown()
    {
        int countdown = 3;

        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }

        countdownText.text = "VAI!";
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        if (dica != null)
        {
            dica.gameObject.SetActive(true);
        }
        panelCountdown.SetActive(false);
        countdownFinished = true;
        timerIsRunning = true;
    }
}
