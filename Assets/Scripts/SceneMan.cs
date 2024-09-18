using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public List<string> sceneNames;

    public void ChangeSceneByIndex(int index)
    {
        if (index >= 0 && index < sceneNames.Count)
        {
            SceneManager.LoadScene(sceneNames[index]);
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
}
