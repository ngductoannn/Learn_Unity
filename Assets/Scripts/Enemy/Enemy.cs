using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Path currentPath;
    [SerializeField] private int currentWayPoint;

    private void Awake()
    {
        currentPath = GameObject.Find("Path1").GetComponent<Path>();
    }

    private void OnEnable()
    {
        currentWayPoint = 0;
        targetPosition = currentPath.GetPosition(currentWayPoint);
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, data.speed*Time.deltaTime);
        float relativeDistance = (transform.position - targetPosition).magnitude; 
        if(relativeDistance < 0.1f)
        {
            if(currentWayPoint < currentPath.WayPoints.Length - 1)
            {
                currentWayPoint++;
                targetPosition = currentPath.GetPosition(currentWayPoint);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

}
