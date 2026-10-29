using System;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObjectPooler[] pool;
    [SerializeField] private int currentPoolIndex;
    [SerializeField] private float timeIntervalPool;

    public static event Action ChangeColor;

    private void Awake()
    {
        currentPoolIndex = 0;
    }

    private void Update()
    {
        timeIntervalPool -= Time.deltaTime;
        spawnTime -= Time.deltaTime;
        if(timeIntervalPool <= 0 && currentPoolIndex < pool.Length)
        {
            currentPoolIndex = currentPoolIndex+1;
            if(currentPoolIndex == pool.Length)
            {
                gameObject.SetActive(false);
            }
            spawnTime = 0;
            timeIntervalPool = 1.5f;

            ChangeColorGray();
        }
        if(spawnTime <= 0)
        {
            if(currentPoolIndex < pool.Length)
            {
                spawnTime = pool[currentPoolIndex].TimeInterval();
                SpawnPrefab();
            }
        }
    }

    private void SpawnPrefab()
    {
        GameObject ois = pool[currentPoolIndex].Pooler();
        ois.transform.position = transform.position;
        ois.SetActive(true);
    }

    private void ChangeColorGray()
    {
        if(currentPoolIndex == pool.Length - 1)
        {
            ChangeColor?.Invoke();
        }
    }
}
