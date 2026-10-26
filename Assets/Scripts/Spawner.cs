using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private WaveData[] waves;
    private int currentWaveIndex = 0;
    private WaveData CurrentWave => waves[currentWaveIndex];
    private float spawnTimer;
    private float spawnCounter;


    [SerializeField] private ObjectPooler skeletonPool;
    [SerializeField] private ObjectPooler batPool;
    [SerializeField] private ObjectPooler t_RexPool;

    private Dictionary<EnemyType, ObjectPooler> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<EnemyType, ObjectPooler>()
        {
            {EnemyType.Skeleton, skeletonPool},
            {EnemyType.Bat, batPool},
            {EnemyType.T_Rex, t_RexPool}
        };
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0 && spawnCounter < CurrentWave.enemiesPerWay)
        {
            spawnTimer = CurrentWave.spawnInterval;
            SpawnEnemy();
            spawnCounter++;
        }
        else if(spawnCounter >= CurrentWave.enemiesPerWay)
        {
            currentWaveIndex = (currentWaveIndex + 1) % waves.Length;
            spawnCounter = 0;
        }
    }

    private void SpawnEnemy()
    {
        if (poolDictionary.TryGetValue(CurrentWave.enemyType, out var pool))
        {
            GameObject spawnedObject = pool.GetPoolObject();
            spawnedObject.transform.position = transform.position;
            spawnedObject.SetActive(true);
        }
    }

}
