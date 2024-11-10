using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMenu : MonoBehaviour
{
    [System.Serializable]
    public class TutorialStep
    {
        [TextArea] public string textoEtapa;
        public List<GameObject> objetosAtivar;
        public List<GameObject> objetosDesativar;
        public List<Animator> animacoesAtivar;
    }

    public List<TutorialStep> etapasTutorial;
    public GameObject painelTutorial;
    public Text caixaTexto;

    private int etapaAtual = 0;
    private bool tutorialAtivo = false;
    public Button botaoIniciarTutorial;

    void Start()
    {
        if (PlayerPrefs.HasKey("TutorialVisto"))
        {
            botaoIniciarTutorial.gameObject.SetActive(false);
        }
    }

    public void VerificarTutorial()
    {
        if (!PlayerPrefs.HasKey("TutorialVisto"))
        {
            StartCoroutine(IniciarTutorialComDelay(140));
            PlayerPrefs.SetInt("TutorialVisto", 1);
            PlayerPrefs.Save();
            botaoIniciarTutorial.gameObject.SetActive(false);
        }
    }

    private IEnumerator IniciarTutorialComDelay(int delayFrames)
    {
        for (int i = 0; i < delayFrames; i++)
        {
            yield return null;
        }
        IniciarTutorial();
    }

    void Update()
    {
        if (tutorialAtivo && Input.GetMouseButtonDown(0))
        {
            ProximaEtapa();
        }
    }

    public void IniciarTutorial()
    {
        tutorialAtivo = true;
        painelTutorial.SetActive(true);
        IniciarEtapa(0);
        etapaAtual = 0;
    }

    private void IniciarEtapa(int indice)
    {
        if (indice < etapasTutorial.Count)
        {
            caixaTexto.text = etapasTutorial[indice].textoEtapa;

            foreach (var obj in etapasTutorial[indice].objetosAtivar)
            {
                obj.SetActive(true);
            }
            foreach (var obj in etapasTutorial[indice].objetosDesativar)
            {
                obj.SetActive(false);
            }

            foreach (var anim in etapasTutorial[indice].animacoesAtivar)
            {
                anim.SetTrigger("Ativar");
            }
        }
    }

    private void ProximaEtapa()
    {
        etapaAtual++;

        if (etapaAtual < etapasTutorial.Count)
        {
            IniciarEtapa(etapaAtual);
        }
        else
        {
            painelTutorial.SetActive(false);
            tutorialAtivo = false;
        }
    }
}
