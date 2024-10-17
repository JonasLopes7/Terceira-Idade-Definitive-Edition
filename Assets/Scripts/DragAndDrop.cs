using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
   private Vector3 startPosition;
    private bool isDragging = false;
    public bool isCorrectlyPlaced = false;
    public string targetTag;
    private Collider2D targetCollider;
    private ObjectMan objectManager; // Referência ao ObjectMan

    // Armazena a rotação inicial do objeto
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation; // Armazena a rotação inicial
        objectManager = FindObjectOfType<ObjectMan>(); // Obter a referência ao ObjectMan
        DragToRotate rotateScript = GetComponent<DragToRotate>();

        if (rotateScript != null)
        {
            rotateScript.enabled = false;
        }
    }

    void OnMouseDown()
    {
        if (!isCorrectlyPlaced)
        {
            startPosition = transform.position;
            isDragging = true;
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        if (!isCorrectlyPlaced)
        {
            transform.position = startPosition;
        }
        else
        {
            transform.position = targetCollider.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            targetCollider = other;
            isCorrectlyPlaced = true;

            // Notifica o ObjectMan que este objeto foi posicionado corretamente
            objectManager.IncrementCorrectlyPlacedCount();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            targetCollider = null;
            isCorrectlyPlaced = false;

            // Notifica o ObjectMan que este objeto foi removido da posição correta
            objectManager.DecrementCorrectlyPlacedCount();
        }
    }

    // Método para teleportar o objeto e resetar a rotação
    public void Teleport()
    {
        transform.rotation = initialRotation; // Reseta a rotação para a inicial
        Debug.Log("n aguento mais");
    }
}