using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnInterval = 1f;

    public GameObject prefabs;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        GameObject spawnedObject = GameObject.Instantiate(prefabs);
        spawnedObject.transform.position = transform.position;
    }
}
