using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    public GameObject projectile;
    public float timeSpawnProjectile;
    private float currentTimer;

    public List<Transform> enemiesInRange = new List<Transform>();

    void Update()
    {
        enemiesInRange.RemoveAll(enemy => enemy == null);
        
        currentTimer -= Time.deltaTime;
        if (enemiesInRange.Count == 0) return;

        if(currentTimer <= 0)
        {
            Shoot();
            currentTimer = timeSpawnProjectile; // Reset thời gian chờ
        }
    }

    void Shoot()
    {
        // 1. Lấy con quái đầu tiên đang đứng trong tầm
        Transform targetEnemy = enemiesInRange[0];

        // 2. Sinh ra viên đạn tại vị trí tháp
        GameObject ois = Instantiate(projectile, transform.position, Quaternion.identity);

        // 3. LẤY SCRIPT PROJECTILE TRÊN VIÊN ĐẠN VÀ TRUYỀN MỤC TIÊU CHO NÓ
        Projectile projScript = ois.GetComponent<Projectile>();
        if (projScript != null && targetEnemy != null)
        {
            projScript.SetTarget(targetEnemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!enemiesInRange.Contains(collision.transform))
            {
                enemiesInRange.Add(collision.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collision.transform);
        }
    }
}