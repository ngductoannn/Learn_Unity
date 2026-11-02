using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerData data;
    private CircleCollider2D circleCollider2D;
    [SerializeField] private List<Enemy> enemiesInRange;
    private ObjectPooler projectilePool;
    private float shootTimer;
    private void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        enemiesInRange = new List<Enemy>();
        projectilePool = GetComponent<ObjectPooler>();
    }

    private void OnEnable()
    {
        Enemy.OnEnemyDestroyed += HandleEnemyDestroyed;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDestroyed -= HandleEnemyDestroyed;
    }

    private void Start()
    {
        circleCollider2D.radius = data.range;
        shootTimer = data.shootInterval;
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        if(shootTimer <= 0)
        {
            Shoot();
            shootTimer = data.shootInterval;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemiesInRange.Remove(enemy);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, data.range);
    }

    private void Shoot()
    {
        if(enemiesInRange.Count > 0)
        {
            GameObject projectile = projectilePool.GetPooledObject();
            projectile.transform.position = transform.position;
            projectile.SetActive(true);
            Vector2 shootDirection = (enemiesInRange[0].transform.position - transform.position).normalized;
            projectile.GetComponent<Projectile>().Shoot(data, shootDirection);
        }
    }

    public void HandleEnemyDestroyed(Enemy enemy)
    {
        enemiesInRange.Remove(enemy);
    }
}
