using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] float speed = 40f;
    [SerializeField] int damage = 1;
    [SerializeField] private GameObject hitEffectPrefab;
    public int Damage => damage;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime *  speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 hitPoint = collision.ClosestPoint(transform.position);

        Instantiate(hitEffectPrefab, hitPoint, Quaternion.identity);
        EnemyBase enemy = collision.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
