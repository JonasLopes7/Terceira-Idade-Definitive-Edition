using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCreditos : MonoBehaviour
{
    public GameObject panel;
    private Animator animator;
    public GameObject tomaluco;

    void Start()
    {
        animator = panel.GetComponent<Animator>();
    }

    public void abre()
    {
        animator.Play("pericles2");
        Debug.Log("aaaaa");
        StartCoroutine(DesativarComDelay());
    }

    public void fecha()
    {
        animator.Play("pericles1");
        tomaluco.SetActive(true);
    }

    private IEnumerator DesativarComDelay()
    {
        yield return new WaitForSeconds(0.5f);
        tomaluco.SetActive(false);
        Debug.Log("asadadasdadadad");
    
    }
}
