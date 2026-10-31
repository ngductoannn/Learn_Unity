using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerData data;
    private CircleCollider2D circleCollider2D;
    [SerializeField] private List<Enemy> enemiesInRange = new List<Enemy>(); 

    private void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        enemiesInRange = new List<Enemy>();
    }

    private void Update()
    {
        circleCollider2D.radius = data.range;
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
}
