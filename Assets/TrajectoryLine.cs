using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPosition, Vector3 endPosition)
    {
        lr.positionCount = 2;
        Vector3[] positions = new Vector3[2];
        positions[0] = startPosition;
        positions[1] = endPosition;

        lr.SetPositions(positions);
    }
    
    public void EndLine()
    {
        lr.positionCount = 0;
    }
}
