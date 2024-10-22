using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontaDoPonteiro : MonoBehaviour
{
    public bool positioned = false;
    public string horaTag;
    private PonteiroMan ponteiroManager;

    void Start()
    {
        ponteiroManager = FindObjectOfType<PonteiroMan>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(horaTag) && !positioned)
        {
            positioned = true;
            ponteiroManager.PonteiroPosicionadoCorretamente();
            Debug.Log("ENTROU POHAAAAAA");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(horaTag) && positioned)
        {
            positioned = false;
            ponteiroManager.PonteiroRemovidoDaPosicao();
        }
    }
}
