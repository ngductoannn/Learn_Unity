using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnInterval = 1f;


    [SerializeField] private ObjectPooler pool;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            spawnTimer = spawnInterval;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject spawnedObject = pool.GetPoolObject();
        spawnedObject.transform.position = transform.position;
        spawnedObject.SetActive(true);
    }

}
