using System;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Wave")]
    [SerializeField] private WaveData[] waves;
    [SerializeField] private int currentWaveIndex = 0;
    private WaveData currentWave => waves[currentWaveIndex];
    private int spawnCounter;
    private float spawnTime;
    private int enemiesRemoved;

    [Header("Pool")]
    [SerializeField] private ObjectPooler orcPool;
    [SerializeField] private ObjectPooler dragonPool;
    [SerializeField] private ObjectPooler kaijuPool;

    private Dictionary<EnemyType, ObjectPooler> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<EnemyType, ObjectPooler>
        {
            {EnemyType.Orc, orcPool},
            {EnemyType.Dragon, dragonPool},
            {EnemyType.Kaiju, kaijuPool}
        };
    }

    private void OnEnable()
    {
        Enemy.OnEnemyReachedEnd += HandleEnemyReachedEnd;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyReachedEnd -= HandleEnemyReachedEnd;
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0 && spawnCounter < currentWave.enemiesPerWave)
        {
            spawnCounter++;
            spawnTime = currentWave.spawnInterval;
            SpawnEnemy();
        }
        else if(spawnCounter >= currentWave.enemiesPerWave && enemiesRemoved >= currentWave.enemiesPerWave)
        {
            currentWaveIndex = (currentWaveIndex + 1)%waves.Length;
            spawnCounter = 0;
            enemiesRemoved = 0;
        }
    }

    private void SpawnEnemy()
    {
        if (poolDictionary.TryGetValue(currentWave.enemyType, out var poolType))
        {
            GameObject ois = poolType.GetPooledObject();
            ois.transform.position = transform.position;
            ois.SetActive(true);
        }
    }

    private void HandleEnemyReachedEnd(EnemyData data)
    {
        enemiesRemoved++;
    }

}
