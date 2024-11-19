using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneMan : MonoBehaviour
{
    public List<string> sceneNames;

    public string tutorialSceneMinigame1 = "TutorialMinigame1";
    public string tutorialSceneMinigame2 = "TutorialMinigame2";

    public int minigame1Index;
    public int minigame2Index;

    public AudioMixer audioMixer;
    private float originalVolume = -20f;

    public void ChangeSceneByIndex(int index)
    {
        if (index >= 0 && index < sceneNames.Count)
        {
            if (index == minigame1Index && PlayerPrefs.GetInt("HasSeenTutorialMinigame1", 0) == 0)
            {
                PlayerPrefs.SetInt("HasSeenTutorialMinigame1", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene(tutorialSceneMinigame1);
            }
            else if (index == minigame2Index && PlayerPrefs.GetInt("HasSeenTutorialMinigame2", 0) == 0)
            {
                PlayerPrefs.SetInt("HasSeenTutorialMinigame2", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene(tutorialSceneMinigame2);
            }
            else
            {
                SceneManager.LoadScene(sceneNames[index]);
                Time.timeScale = 1;
                audioMixer.SetFloat("Musica", originalVolume);
            }
        }
        else
        {
            Debug.LogWarning("Índice fora dos limites da lista de cenas!");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void ResetTutorials()
{
    PlayerPrefs.DeleteKey("HasSeenTutorialMinigame1");
    PlayerPrefs.DeleteKey("HasSeenTutorialMinigame2");
    PlayerPrefs.Save();
    Debug.Log("Status dos tutoriais foi resetado.");
}
}
