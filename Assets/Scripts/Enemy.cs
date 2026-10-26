using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Path path;
    [SerializeField] private Vector3 target;
    [SerializeField] private int currentWayPoint;

    private void Awake()
    {
        path = GameObject.Find("Path").GetComponent<Path>();
    }

    private void OnEnable()
    {
        currentWayPoint = 0;
        target = path.GetPosition(currentWayPoint);
    }

    private void Update()
    {
        if(transform.position == target)
        {
            if(currentWayPoint < path.wayPoints.Length - 1)
            {
                currentWayPoint++;
            }
            else
            {
                gameObject.SetActive(false);
            }
            target = path.GetPosition(currentWayPoint);
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }
}
