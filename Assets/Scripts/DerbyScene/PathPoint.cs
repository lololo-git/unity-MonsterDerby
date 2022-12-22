using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    Vector2 nextPosition;

    public void SetNextPoint(Vector2 pos)
    {
        nextPosition = pos;
    }

    public Vector2 GetNextPosition()
    {
        return nextPosition;
    }
}
