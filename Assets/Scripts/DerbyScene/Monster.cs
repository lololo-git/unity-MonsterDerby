using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster: MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public Vector2 nextPoint;

    new Rigidbody2D rigidbody;


    public void SetNextPoint(Vector2 point)
    {
        nextPoint = point;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var point = collision.GetComponent<PathPoint>();
        if (!point)
            return;
        SetNextPoint(point.GetNextPosition());

        // For test
        float bonus = Random.Range(0, 2f);
        if (acceleration > Parameters.Instance.MonsterDefaultAcceleration)
            bonus *= -1;
        acceleration += bonus;
    }

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        maxSpeed = Parameters.Instance.MonsterDefaultMaxSpeed;
        acceleration = Parameters.Instance.MonsterDefaultAcceleration;

        // For test
        maxSpeed += Random.Range(-2f, 2f);
        acceleration += Random.Range(-2f, 2f);
    }

    void FixedUpdate()
    {
        Vector2 force = nextPoint - (Vector2)transform.localPosition;
        force = force.normalized * acceleration;
        if (rigidbody.velocity.magnitude < maxSpeed) {
            rigidbody.AddForce(force);
        }

        // fix rendering order
        Vector3 pos = transform.localPosition;
        pos.z = pos.y / 10;
        transform.localPosition = pos;

        if (IsGoingRight() != IsFacingRight())
            FlipSprite();        
    }

    bool IsGoingRight() => rigidbody.velocity.x > 0;

    bool IsFacingRight() => transform.localScale.x > 0;

    void FlipSprite()
    {
        Vector2 scale = transform.localScale;
        scale.x = scale.x * -1;
        transform.localScale = scale;
    }
}