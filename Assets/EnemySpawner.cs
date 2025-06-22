using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 2f;
    public float spawnDistance = 10f;

    float elapsedTime = 0f;
    int maxEnemyTier = 0;

    private Transform player;


    public GameObject bossPrefab;
    public float bossSpawnTime = 90f;
    private bool bossSpawned = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 30f) maxEnemyTier = 1;
        if (elapsedTime > 60f) maxEnemyTier = 2;

        if (!bossSpawned && elapsedTime >= bossSpawnTime)
        {
            SpawnBoss();
            bossSpawned = true;
        }
    }


    void SpawnEnemy()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player")?.transform;
            if (player == null) return;
        }

        Vector2 randomDir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)player.position + randomDir * spawnDistance;

        int tier = Random.Range(0, Mathf.Clamp(maxEnemyTier + 1, 1, enemyPrefabs.Length));
        Instantiate(enemyPrefabs[tier], spawnPos, Quaternion.identity);
    }

    void SpawnBoss()
    {
        if (player == null) return;

        Vector2 randomDir = Random.insideUnitCircle.normalized;
        Vector2 spawnPos = (Vector2)player.position + randomDir * (spawnDistance + 2f); // spawn farther

        Instantiate(bossPrefab, spawnPos, Quaternion.identity);
        Debug.Log("Boss Spawned!");
    }


}
