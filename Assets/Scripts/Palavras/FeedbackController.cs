using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackController : MonoBehaviour
{
    public float animationDuration = 20f / 60f;

    void Start()
    {
        Destroy(gameObject, animationDuration);
    }
}
