using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected int maxHealth = 3;
    protected int currentHealth;
    [SerializeField] protected float speed = 5f;

    [Header("Death")]
    [SerializeField] protected GameObject deathEffectPrefab;
    [SerializeField] protected AudioClip deathSound;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        
        if (EnemyManager.Instance != null)
            EnemyManager.Instance.RegisterEnemy();
    }

    protected virtual void Update()
    {
        Move();
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {        
        if (deathEffectPrefab != null)
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);

        if (deathSound != null)
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 1.5f);

        if (EnemyManager.Instance != null)
            EnemyManager.Instance.UnregisterEnemy();

        Destroy(gameObject);
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Die();
        }
    }
}
