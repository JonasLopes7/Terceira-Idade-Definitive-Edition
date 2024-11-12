using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTeste : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public float swipeThreshold = 50f;

    public AnimatorMenu animatorMenu;

    private void Update()
    {
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                CheckSwipe();
            }
        }
    }

    private void CheckSwipe()
    {
        float swipeDistance = endTouchPosition.x - startTouchPosition.x;

        if (Mathf.Abs(swipeDistance) > swipeThreshold)
        {
            if (swipeDistance > 0)
            {
                animatorMenu.HidePanel();
            }
            else
            {
                animatorMenu.ShowPanel();
            }
        }
    }
}
