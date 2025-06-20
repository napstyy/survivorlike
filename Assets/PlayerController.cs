using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    public GameObject projectilePrefab;
    public float fireRate = 1f;
    private float fireTimer;
    public int damage = 1;
    public int projectileCount = 1;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    void Shoot()
    {
        GameObject target = FindClosestEnemy();
        if (target == null) return;

        Vector2 direction = (target.transform.position - transform.position).normalized;
        float angleStep = 10f;
        float startAngle = -((projectileCount - 1) / 2f) * angleStep;

        for (int i = 0; i < projectileCount; i++)
        {
            float angle = startAngle + i * angleStep;
            Vector2 rotatedDir = Quaternion.Euler(0, 0, angle) * direction;

            GameObject proj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile p = proj.GetComponent<Projectile>();
            p.SetDirection(rotatedDir);
            p.SetDamage(damage);
        }
    }




    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = (enemy.transform.position - transform.position).sqrMagnitude;
            if (dist < minDist)
            {
                minDist = dist;
                closest = enemy;
            }
        }

        return closest;
    }


    public void IncreaseFireRate(float amount)
    {
        fireRate = Mathf.Max(0.1f, fireRate - amount);
    }

    public void IncreaseDamage(int amount)
    {
        damage += amount;
    }
    public void IncreaseProjectileCount(int amount)
    {
        projectileCount += amount;
    }


}
