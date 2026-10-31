using UnityEngine;

public class Projectile : MonoBehaviour
{
    private TowerData data;
    private Vector3 shootDirection;
    private float projectDuration;
    
    void Update()
    {
        if(projectDuration <= 0)
        {
            gameObject.SetActive(false);

        }
        else
        {
            projectDuration -= Time.deltaTime;
            transform.position += new Vector3(shootDirection.x, shootDirection.y, 0)*data.projectileSpeed*Time.deltaTime;
        }
    }

    public void Shoot(TowerData dt, Vector3 direction)
    {
        data = dt;
        shootDirection = direction;
        projectDuration = data.projectileDurations;
    }
    
}
