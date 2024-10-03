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
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            targetCollider = null;
            isCorrectlyPlaced = false;
        }
    }
}