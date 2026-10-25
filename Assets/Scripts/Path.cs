using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject[] WayPoints;
    private void OnDrawGizmos()
    {
        if(WayPoints.Length > 0)
        {
            for(int i = 0; i < WayPoints.Length-1; i++)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(WayPoints[i].transform.position, WayPoints[i+1].transform.position);
            }
        }
    }
}
