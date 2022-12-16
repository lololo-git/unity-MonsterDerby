using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Monster: MonoBehaviour
{
    float maxSpeed;
    float acceleration;

    Vector2 accel;

    new Rigidbody2D rigidbody;

    void Start()
    {
        maxSpeed = 5.0f;
        acceleration = 10.0f;

        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var pos = transform.localPosition;
        if (Screen.width / 2 < pos.x)
        {
            pos.x = Screen.width / 2 * -1;
            transform.localPosition = pos;
        }

        accel = new Vector2(acceleration, 0);
        if (rigidbody.velocity.magnitude < maxSpeed) {
            rigidbody.AddForce(accel);
        }
    }
}
