using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMan : MonoBehaviour
{
    public DragAndDrop[] draggableObjects;

    public int correctlyPlacedCount = 0;
    public const int totalRequired = 3;
    public bool isActivated = false;
    public GameObject textoHora;

    void Update()
    {
        if (correctlyPlacedCount >= totalRequired && !isActivated)
        {
            ActivateDragToRotate();
            isActivated = true;
            textoHora.SetActive(true);
        }
    }

    public void IncrementCorrectlyPlacedCount()
    {
        correctlyPlacedCount++;
        Debug.Log("Contador de objetos corretamente posicionados: " + correctlyPlacedCount);
        isActivated = false;
    }

    public void DecrementCorrectlyPlacedCount()
    {
        correctlyPlacedCount--;
        Debug.Log("Contador de objetos corretamente posicionados: " + correctlyPlacedCount);
    }

    private void ActivateDragToRotate()
    {
        foreach (DragAndDrop draggable in draggableObjects)
        {
            DragToRotate rotateScript = draggable.GetComponent<DragToRotate>();
            if (rotateScript != null)
            {
                rotateScript.enabled = true;
                Debug.Log("quero dar o rabo2024");
            }
        }
    }
}
