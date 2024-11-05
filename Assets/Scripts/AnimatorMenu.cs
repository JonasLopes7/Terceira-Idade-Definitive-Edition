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

    void Start()
    {
        animatorPalavra = panelPal.GetComponent<Animator>();
        animatorRelogio = panelRel.GetComponent<Animator>();
        panelPal.SetActive(true);
        panelRel.SetActive(false);
    }
    public void ShowPal() 
    {
        ShowPanelPal();
        HidePanelRel();    //mostra o panelPal e esconde o panelRel
    } 
    public void ShowRel()
    {
        ShowPanelRel();
        HidePanelPal();   //mostra o panelRel e esconde o panelPal
    }
    public void ShowPanelPal()
    {
        panelPal.SetActive(true);
        animatorPalavra.Play("animacaoPainelPalavra");
    }

    public void HidePanelPal()
    {
        animatorPalavra.Play("animacaoPainelPalavraVolta");
        Invoke("DisablePanelPal", 0.5f);
    }

    private void DisablePanelPal()
    {
        panelPal.SetActive(false); // Desativa o painel
    }
    public void ShowPanelRel()
    {
        panelRel.SetActive(true);
        animatorRelogio.Play("animacaoPainelRelogio");
    }

    public void HidePanelRel()
    {
        animatorRelogio.Play("animacaoPainelRelogioVolta");
        Invoke("DisablePanelRel", 0.5f);
    }

    private void DisablePanelRel()
    {
        panelRel.SetActive(false); // Desativa o painel
    }
}
