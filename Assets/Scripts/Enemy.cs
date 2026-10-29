using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Path currentPath;
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
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime*moveSpeed);

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
                gameObject.SetActive(false);
            }
        }
    }
}
