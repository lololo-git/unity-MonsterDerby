using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path: MonoBehaviour
{
    [SerializeField] GameObject pathPointPrefab;
    [SerializeField] GameObject track;

    GameObject[] points;

    public Vector2 GetFirstPoint()
    {
        if (points == null)
            points = CreatePathPoints();
        return points[0].transform.position;
    }

    private void Start()
    {
        points = CreatePathPoints();
    }

    private GameObject[] CreatePathPoints()
    {
        float baseSize = track.transform.localScale.x / 2;
        int circlePointNum = 10;
        float colliderSpan = baseSize / 10;
        var points = new GameObject[circlePointNum * 2];
        float radius = baseSize + colliderSpan;
        float angleScale = Mathf.PI / (circlePointNum - 1);

        float angle = Mathf.PI / 2.0f;
        for (var i = 0; i < circlePointNum; i++)
        {
            points[i] = Instantiate(pathPointPrefab, transform);
            points[i].transform.position = new Vector2(Mathf.Cos(angle) * radius + baseSize, Mathf.Sin(angle) * radius);
            points[i].transform.Rotate(transform.forward, angle / Mathf.PI * 180);
            angle -= angleScale;
        }
        angle = Mathf.PI * 1.5f;
        for (var i = circlePointNum; i < circlePointNum * 2; i++)
        {
            points[i] = Instantiate(pathPointPrefab, transform);
            points[i].transform.position = new Vector2(Mathf.Cos(angle) * radius - baseSize, Mathf.Sin(angle) * radius);
            points[i].transform.Rotate(transform.forward, angle / Mathf.PI * 180);
            angle -= angleScale;
        }

        // SetNextPoints
        for (var i = 0; i < points.Length; i++)
        {
            int nextIndex = (i + 1) % points.Length;
            points[i].GetComponent<PathPoint>().SetNextPoint(points[nextIndex].transform.position);
        }
        return points;
    }
}