using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorMenu : MonoBehaviour
{
    public GameObject panelPal;
    public GameObject panelRel;
    private Animator animatorPalavra;
    private Animator animatorRelogio;
    public CanvasGroup canvasGroup;

    void Start()
    {
        animatorPalavra = panelPal.GetComponent<Animator>();
        animatorRelogio = panelRel.GetComponent<Animator>();
        panelPal.SetActive(false);
        panelRel.SetActive(false);
    }

    public void ShowPanelPal()
    {
        panelPal.SetActive(true);
        animatorPalavra.Play("animacaoPainelPalavra");
        canvasGroup.interactable = false;
    }

    public void HidePanelPal()
    {
        animatorPalavra.Play("animacaoPainelPalavraVolta");
        Invoke("DisablePanelPal", 0.5f);
        canvasGroup.interactable = true;
    }

    private void DisablePanelPal()
    {
        panelPal.SetActive(false); // Desativa o painel
    }
    public void ShowPanelRel()
    {
        panelRel.SetActive(true);
        animatorRelogio.Play("animacaoPainelRelogio");
        canvasGroup.interactable = false;
    }

    public void HidePanelRel()
    {
        animatorRelogio.Play("animacaoPainelRelogioVolta");
        Invoke("DisablePanelRel", 0.5f);
        canvasGroup.interactable = true;
    }

    private void DisablePanelRel()
    {
        panelRel.SetActive(false); // Desativa o painel
    }
}
