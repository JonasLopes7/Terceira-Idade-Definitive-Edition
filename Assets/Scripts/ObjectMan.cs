using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMan : MonoBehaviour
{
    public DragAndDrop[] draggableObjects;

    // Contador para rastrear quantos objetos estão posicionados corretamente
    public int correctlyPlacedCount = 0;
    public const int totalRequired = 3; // Mude para o número total que você deseja
    public bool isActivated = false;

    void Update()
    {
        // Se todos os objetos estão posicionados corretamente e o estado não foi definido como verdadeiro ainda
        if (correctlyPlacedCount >= totalRequired && !isActivated)
        {
            ActivateDragToRotate(); // Ativa o script de rotação
            isActivated = true; // Define como ativado
        }
    }

    // Método para incrementar o contador de objetos posicionados corretamente
    public void IncrementCorrectlyPlacedCount()
    {
        correctlyPlacedCount++;
        Debug.Log("Contador de objetos corretamente posicionados: " + correctlyPlacedCount);
        isActivated = false;
    }

    // Método para decrementar o contador de objetos posicionados corretamente
    public void DecrementCorrectlyPlacedCount()
    {
        correctlyPlacedCount--;
        Debug.Log("Contador de objetos corretamente posicionados: " + correctlyPlacedCount);
    }

    // Método para ativar o script de rotação
    private void ActivateDragToRotate()
    {
        foreach (DragAndDrop draggable in draggableObjects)
        {
            DragToRotate rotateScript = draggable.GetComponent<DragToRotate>();
            if (rotateScript != null)
            {
                rotateScript.enabled = true; // Ativa o script de rotação
                Debug.Log("quero dar o rabo2024");
            }
        }
    }
}
