using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolinha : MonoBehaviour
{
    public Rigidbody2D ball;
    public float speed = 10f;

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
        {
            Debug.LogError("ai fudeu neh pai");
        }
    }

    void Update()
    {
        if (Input.gyro.enabled)
        {
            Vector3 tilt = Input.gyro.gravity;

            Debug.Log("Giroscópio - X: " + tilt.x + " | Y: " + tilt.y + " | Z: " + tilt.z);

            Vector2 movement = new Vector2(tilt.x, tilt.y);

            ball.AddForce(movement * speed);
        }
    }
}
