using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float spawnTime;
    private float spawnInterval;

    [SerializeField] private ObjectPooler pool;

    private void Start()
    {
        spawnInterval = 1;
        spawnTime = 0.5f;
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            spawnTime = spawnInterval;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject ois = pool.GetPooledObject();
        ois.transform.position = transform.position;
        ois.SetActive(true);
    }
}
