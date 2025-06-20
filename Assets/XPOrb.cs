using UnityEngine;

public class XPOrb : MonoBehaviour
{
    public int xpValue = 1;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        
        float dist = Vector2.Distance(transform.position, player.position);
        if (dist < 3f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, 5f * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerXP playerXP = other.GetComponent<PlayerXP>();
            if (playerXP != null)
            {
                playerXP.AddXP(xpValue);
                Destroy(gameObject);
            }
        }
    }
}
