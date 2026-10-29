using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    public static event Action<EnemyData> OnEnemyReachedEnd;
    private Path currentPath;
    private Vector3 targetPosition;
    private int currentWayPoint;

    private void Awake()
    {
        currentPath = GameObject.Find("Path1").GetComponent<Path>();
    }

    private void OnEnable()
    {
        currentWayPoint = 0;
        targetPosition = currentPath.GetPosition(currentWayPoint);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime*data.speed);

        float relativeDistance = (transform.position - targetPosition).magnitude;
        if(relativeDistance < 0.1f)
        {
            if(currentWayPoint < currentPath.WayPoints.Length - 1)
            {
                currentWayPoint+=1;
                targetPosition = currentPath.GetPosition(currentWayPoint);
            }
            else
            {
                OnEnemyReachedEnd?.Invoke(data);
                gameObject.SetActive(false);
            }
        }
    }
}
