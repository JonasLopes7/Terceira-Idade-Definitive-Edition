using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToRotate : MonoBehaviour
{
    public Transform pivotPoint;
    private bool isDragging = false;

    private PontaDoPonteiro pontaPonteiro;

    public GameObject Ponta;

    void Start()
    {
        pontaPonteiro = FindObjectOfType<PontaDoPonteiro>();
        Debug.Log("vasco");
        Ponta.SetActive(true);
    }

    void Update()
    {
        if (!enabled)
        {
            return;
        }
    }

    void OnMouseDown()
    {
        if (!enabled) return;
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!enabled) return;

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            Vector3 direction = mousePosition - pivotPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.RotateAround(pivotPoint.position, Vector3.forward, angle - transform.eulerAngles.z);
        }
    }

    void OnMouseUp()
    {
        if (!enabled) return;
        isDragging = false;
    }
}
