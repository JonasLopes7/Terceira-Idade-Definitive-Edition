using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
   private Vector3 startPosition;
    private bool isDragging = false;
    public bool isCorrectlyPlaced = false;
    public string targetTag;

    void OnMouseDown()
    {
        startPosition = transform.position;
        isDragging = true;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

    void OnMouseUp()
    {
        isDragging = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        if (hitCollider != null && hitCollider.CompareTag(targetTag))
        {
            transform.position = hitCollider.transform.position;
            isCorrectlyPlaced = true;
        }
        else
        {
            transform.position = startPosition;
            isCorrectlyPlaced = false;
        }
    }
}
