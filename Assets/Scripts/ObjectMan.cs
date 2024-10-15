using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMan : MonoBehaviour
{
    public DragAndDrop[] draggableObjects;

    void Update()
    {
        if (AllObjectsCorrectlyPlaced())
        {
            foreach (DragAndDrop draggable in draggableObjects)
            {
                DragToRotate rotateScript = draggable.GetComponent<DragToRotate>();
                if (rotateScript != null)
                {
                    rotateScript.enabled = true;
                }
            }
        }
    }

    bool AllObjectsCorrectlyPlaced()
    {
        foreach (DragAndDrop draggable in draggableObjects)
        {
            if (!draggable.isCorrectlyPlaced)
            {
                return false;
            }
        }
        return true;
    }
}
