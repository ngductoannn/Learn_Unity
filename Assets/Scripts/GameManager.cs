using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<int> OnLivesChanged;

    private int lives = 5;

    private void OnEnable()
    {
        Enemy.OnEnemyReachedEnd += HandleEnemyReachedEnd;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyReachedEnd -= HandleEnemyReachedEnd;
    }

    private void Start()
    {
        OnLivesChanged?.Invoke(lives);
    }

    private void HandleEnemyReachedEnd(EnemyData data)
    {
        lives = Mathf.Max(0, lives - data.damage);
        OnLivesChanged?.Invoke(lives);
    }
}

