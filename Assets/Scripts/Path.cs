using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Path : MonoBehaviour
{
    public  GameObject[] wayPoints;

    private void Awake()
    {
        
    }
    private void OnDrawGizmos()
    {
        if(wayPoints.Length > 0)
        {
            for(int i = 0; i < wayPoints.Length; i++)
            {
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.white;
                style.alignment = TextAnchor.MiddleCenter;
                Handles.Label(wayPoints[i].transform.position + Vector3.up, wayPoints[i].name, style);

                if(i != wayPoints.Length - 1)
                {
                    Gizmos.color = Color.gray;
                    Gizmos.DrawLine(wayPoints[i].transform.position, wayPoints[i+1].transform.position);
                }
            }
        }
    }

    public Vector3 GetPosition(int index)
    {
        return wayPoints[index].transform.position;
    }

}
