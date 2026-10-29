using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Objects/WaveData")]
public class WaveData : ScriptableObject
{
    public EnemyType enemyType;
    public float spawnInterval;
    public int enemiesPerWave;
}
