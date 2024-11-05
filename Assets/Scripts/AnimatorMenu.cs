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
    }

    public void HidePanel()
    {
        animator.Play("anim2");
    }
}
