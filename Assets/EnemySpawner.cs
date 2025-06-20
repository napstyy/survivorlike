using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnDistance = 10f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        Vector2 randomDir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)player.position + randomDir * spawnDistance;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
