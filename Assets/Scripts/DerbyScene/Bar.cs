using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public bool isGoingDown;
    float acceleration, speed, maxSpeed;
    Vector2 position;

    private void Start()
    {
        acceleration = Parameters.Instance.BarAcceleration;
        maxSpeed = Parameters.Instance.BarMaxSpeed;
        isGoingDown = true;
        speed = 0;
        position = gameObject.transform.localPosition;
    }

    void FixedUpdate()
    {
        speed += acceleration * (isGoingDown ? -1 : 1);
        if (maxSpeed < Mathf.Abs(speed))
            speed = speed / Mathf.Abs(speed) * maxSpeed;
        position.y += speed;
        gameObject.transform.localPosition = position;

        if (80 < position.y)
            isGoingDown = true;
        else if (position.y < -80)
            isGoingDown = false;
    }
}
