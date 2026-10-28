using System;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObjectPooler pool;


    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            spawnTime = pool.TimeInterval();
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        GameObject ois = pool.Pooler();
        ois.transform.position = transform.position;
        ois.SetActive(true);
    }
}
