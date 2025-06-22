using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 1;

    private Vector2 direction;




    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Boss boss = other.GetComponent<Boss>();

            if (enemy != null) enemy.TakeDamage(damage);
            else if (boss != null) boss.TakeDamage(damage);

            Destroy(gameObject);
        }
    }


    public void SetDamage(int dmg)
    {
        damage = dmg;
    }



}
