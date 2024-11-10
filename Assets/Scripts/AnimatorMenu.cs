using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorMenu : MonoBehaviour
{
    public GameObject panel;
    private Animator animator;

    void Start()
    {
        animator = panel.GetComponent<Animator>();
    }

    public void ShowPanel()
    {
        animator.Play("anim1");
        Debug.Log("aaaaa");
    }

    public void HidePanel()
    {
        animator.Play("anim2");
    }
    public void GoPlay1()
    {
        animator.Play("anim3");
    }

    public void GoMenu1()
    {
        animator.Play("anim4");
    }

    public void GoPlay2()
    {
        animator.Play("anim5");
    }

    public void GoMenu2()
    {
        animator.Play("anim6");
    }
}
