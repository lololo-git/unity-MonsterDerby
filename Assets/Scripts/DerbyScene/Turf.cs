using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turf : MonoBehaviour
{
    [SerializeField] GameObject[] barriers;
    [SerializeField] Path path;

    int barrierNum;

    public Vector2 GetFirstPoint()
    {
        return path.GetFirstPoint();
    }

    public Vector2 GetBarrierPoint(int num)
    {
        var order = num;
        if (order < 0 || barriers.Length < order)
        {
            Debug.LogError("wrong num");
            order = 0;
        }
        return barriers[order].transform.position;
    }
}
