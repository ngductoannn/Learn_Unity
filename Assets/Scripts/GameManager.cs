using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnLivesChanged;
    public static event Action<float> OnResourcesChanged;

    private int lives = 5;
    [SerializeField] private float resources = 0;

    private void OnEnable()
    {
        Enemy.OnEnemyReachedEnd += HandleEnemyReachedEnd;
        Enemy.OnEnemyDestroyed += HandleEnemyDestroyed;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyReachedEnd -= HandleEnemyReachedEnd;
        Enemy.OnEnemyDestroyed -= HandleEnemyDestroyed;
    }

    private void Start()
    {
        OnLivesChanged?.Invoke(lives);
        OnResourcesChanged?.Invoke(resources);
    }

    private void HandleEnemyReachedEnd(EnemyData data)
    {
        lives = Mathf.Max(0, lives - data.damage);
        OnLivesChanged?.Invoke(lives);
    }

    private void HandleEnemyDestroyed(Enemy enemy)
    {
        addResources((int)enemy.Data.resourceReward);
    }

    private void addResources(float amount)
    {
        resources += amount;
        OnResourcesChanged?.Invoke(resources);
    }
}

