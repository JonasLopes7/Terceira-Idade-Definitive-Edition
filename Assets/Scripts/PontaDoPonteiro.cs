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
        // Encontra o manager na cena
        ponteiroManager = FindObjectOfType<PonteiroMan>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(horaTag) && !positioned)
        {
            positioned = true;
            // Notifica o manager que este ponteiro foi posicionado corretamente
            ponteiroManager.PonteiroPosicionadoCorretamente();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(horaTag) && positioned)
        {
            positioned = false;
            // Notifica o manager que este ponteiro saiu da posição correta
            ponteiroManager.PonteiroRemovidoDaPosicao();
        }
    }
}
