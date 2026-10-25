using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject[] WayPoints;
    private void OnDrawGizmos()
    {   
        if(WayPoints.Length > 0)
        {
            for(int i = 0; i < WayPoints.Length; i++)
            {
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.white;
                style.alignment = TextAnchor.MiddleCenter;
                Handles.Label(WayPoints[i].transform.position + Vector3.up, WayPoints[i].name, style);

                if(i != WayPoints.Length - 1)
                {
                    Gizmos.color = Color.gray;
                    Gizmos.DrawLine(WayPoints[i].transform.position, WayPoints[i+1].transform.position);
                }
            }
        }
    }
}
