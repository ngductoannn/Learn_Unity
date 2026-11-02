using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    public static event Action<EnemyData> OnEnemyReachedEnd;
    public static event Action<Enemy> OnEnemyDestroyed;
    private Path currentPath;
    private Vector3 targetPosition;
    private int currentWayPoint;
    private float lives;
    [SerializeField] private Transform healthBar;
    private Vector3 healthBarOriginalScale;

    private void Awake()
    {
        currentPath = GameObject.Find("Path1").GetComponent<Path>();
        healthBarOriginalScale = healthBar.localScale;
    }

    private void OnEnable()
    {
        currentWayPoint = 0;
        targetPosition = currentPath.GetPosition(currentWayPoint);
        lives = data.lives;
        UpdateHealthBar();
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

    public void TakeDamage(float damage)
    {
        lives -= damage;
        lives = Mathf.Max(lives, 0);
        UpdateHealthBar();
        if(lives <= 0)
        {
            OnEnemyDestroyed?.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    private void UpdateHealthBar()
    {
        float healthPercen = lives / data.lives;
        Vector3 scale = healthBarOriginalScale;
        scale.x = healthPercen * healthBarOriginalScale.x;
        healthBar.localScale = scale;
    }

}
