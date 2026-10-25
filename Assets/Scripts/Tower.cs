using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject[] tower;

    private void OnDrawGizmos()
    {
        for(int i = 0; i < tower.Length; i++)
        {
            Gizmos.color = Color.gray;
            if(i < tower.Length - 1)
            {
                Gizmos.DrawLine(tower[i].transform.position, tower[i+1].transform.position);
            }
        }
    }
}
