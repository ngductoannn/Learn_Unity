using System;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObjectPooler[] pool;
    [SerializeField] private int currentPoolIndex;
    [SerializeField] private float timeIntervalPool;

    private void Awake()
    {
        currentPoolIndex = 0;
    }

    private void Update()
    {
        timeIntervalPool -= Time.deltaTime;
        spawnTime -= Time.deltaTime;
        if(timeIntervalPool <= 0 && currentPoolIndex < pool.Length-1)
        {
            currentPoolIndex++;
            spawnTime = 0;
            timeIntervalPool = 3f;
        }
        if(spawnTime <= 0)
        {
            spawnTime = pool[currentPoolIndex].TimeInterval();
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        GameObject ois = pool[currentPoolIndex].Pooler();
        ois.transform.position = transform.position;
        ois.SetActive(true);
    }
}
