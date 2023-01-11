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
        var order = num % barrierNum;
        return barriers[order].transform.position;
    }

    void Start()
    {
        barrierNum = barriers.Length;
    }
}
