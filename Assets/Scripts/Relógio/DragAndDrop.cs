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
    private ObjectMan objectManager;
    private Quaternion initialRotation;
    public bool hasIncremented = false;

    void Start()
    {
        initialRotation = transform.rotation;
        objectManager = FindObjectOfType<ObjectMan>();
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

        if (isCorrectlyPlaced && targetCollider != null && !hasIncremented) // Verifica se já foi incrementado
        {
            transform.position = targetCollider.transform.position + new Vector3(0, 0, -5);

            // Incrementa o contador apenas uma vez
            objectManager.IncrementCorrectlyPlacedCount();
            hasIncremented = true; // Marca como incrementado
        }
        else if (!isCorrectlyPlaced)
        {
            transform.position = startPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            targetCollider = other;
            isCorrectlyPlaced = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            targetCollider = null;
            isCorrectlyPlaced = false;
            hasIncremented = false;
        }
    }

    public void Teleport()
    {
        transform.rotation = initialRotation;
        Debug.Log("n aguento mais");
    }
}