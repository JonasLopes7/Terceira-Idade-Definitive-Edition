using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHands : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isDragging = false;
    public Transform hourHand;
    public Transform minuteHand;
    public Vector3 correctHourHandPosition;
    public Vector3 correctMinuteHandPosition;

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
        // Verificar se o ponteiro está na posição correta
        if (transform == hourHand && Vector3.Distance(transform.position, correctHourHandPosition) < 0.1f)
        {
            transform.position = correctHourHandPosition;
        }
        else if (transform == minuteHand && Vector3.Distance(transform.position, correctMinuteHandPosition) < 0.1f)
        {
            transform.position = correctMinuteHandPosition;
        }
        else
        {
            transform.position = startPosition;
        }
    }
}
