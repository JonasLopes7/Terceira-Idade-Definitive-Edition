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

    void Start()
    {

    }

    void Update()
    {
        if (tutorialAtivo && Input.GetMouseButtonDown(0))
        {
            ProximaEtapa();
        }
    }

    // Método chamado pelo botão para iniciar o tutorial
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
            // Atualiza o texto para a etapa atual
            caixaTexto.text = etapasTutorial[indice].textoEtapa;

            // Ativa e desativa objetos conforme a etapa
            foreach (var obj in etapasTutorial[indice].objetosAtivar)
            {
                obj.SetActive(true); // Apenas ativa objetos
            }
            foreach (var obj in etapasTutorial[indice].objetosDesativar)
            {
                obj.SetActive(false); // Apenas desativa objetos
            }

            // Ativa animações conforme a etapa
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
            // Finaliza o tutorial
            painelTutorial.SetActive(false);
            tutorialAtivo = false;
        }
    }
}
