using UnityEngine;

public class Enemy : MonoBehaviour
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
                Instantiate(xpOrbPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
