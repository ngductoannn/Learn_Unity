using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform targetEnemy; // Lưu mục tiêu riêng của viên đạn này
    public float speed = 5f;       // Tốc độ bay của đạn

    // Hàm này sẽ được Tháp gọi ngay sau khi bắn ra
    public void SetTarget(Transform enemyTransform)
    {
        targetEnemy = enemyTransform;
    }

    void Update()
    {
        // Nếu con quái mục tiêu bị tiêu hủy (chết), viên đạn tự hủy theo để tránh lỗi
        if (targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }

        // Bay đuổi theo đúng con quái đó
        transform.position = Vector3.MoveTowards(transform.position, targetEnemy.position, Time.deltaTime * speed);
        
        // (Tùy chọn) Nếu đạn chạm tới sát vị trí quái thì gây sát thương và tự hủy viên đạn
        if (Vector3.Distance(transform.position, targetEnemy.position) < 0.2f)
        {
            // Trừ máu quái ở đây nếu muốn...
            Destroy(gameObject);
        }
    }
}