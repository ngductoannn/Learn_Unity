using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject[] tower;

    private void OnDrawGizmos()
    {
        for(int i = 0; i < tower.Length; i++)
        {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.MiddleCenter;
            Handles.Label(tower[i].transform.position + Vector3.up * 1.5f, "tower (" + (i+1) + ")", style);

            Gizmos.color = Color.gray;
            if(i < tower.Length - 1)
            {
                Gizmos.DrawLine(tower[i].transform.position, tower[i+1].transform.position);
            }
        }
    }

    public Vector3 GetPosition(int index)
    {
        return tower[index].transform.position;
    }
}
