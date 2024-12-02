using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroMan : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena que será carregada.

    private VideoPlayer videoPlayer;

    void Start()
    {
        // Obter o componente VideoPlayer no mesmo GameObject.
        videoPlayer = GetComponent<VideoPlayer>();

        // Assinar o evento de término do vídeo.
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Carregar a cena especificada.
        SceneManager.LoadScene(sceneToLoad);
    }
}
