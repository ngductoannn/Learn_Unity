using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private float distanceTime;
    [SerializeField] private ObjectPooler pool;

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            SpawnEnemy();
            spawnTime = distanceTime;
        }
    }

    private void SpawnEnemy()
    {
        GameObject spawnedObject = pool.GetPooledObject();
        spawnedObject.transform.position = transform.position;
        spawnedObject.SetActive(true);
    }
}
