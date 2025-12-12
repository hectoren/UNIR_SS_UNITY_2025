using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    [SerializeField] float minShootTime = 1f;
    [SerializeField] float maxShootTime = 4f;

    private float shootTimer;

    void Start()
    {
        ResetShootTimer();
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            Shoot();
            ResetShootTimer();
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void ResetShootTimer()
    {
        shootTimer = Random.Range(minShootTime, maxShootTime);
    }
}
