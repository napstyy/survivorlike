using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 3;

    public float moveSpeed = 2f;
    private Transform player;
    public GameObject xpOrbPrefab;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 dir = (player.position - transform.position).normalized;
        transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            if (xpOrbPrefab != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    Vector2 offset = Random.insideUnitCircle * 1.5f; // tweak 1.5f for spread radius
                    Vector2 spawnPos = (Vector2)transform.position + offset;
                    Instantiate(xpOrbPrefab, spawnPos, Quaternion.identity);
                }
            }

            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(1);
                Debug.Log("Hit player");

            }

            Destroy(gameObject); // Optional
        }
    }



}
