using UnityEngine;

public class Enemy_9 : EnemyBase
{
    Vector3 linearVelocity = Vector3.down;

    protected override void Move()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);

        if (transform.position.y < -14)
        {
            linearVelocity = Vector3.up;
        }
        if (transform.position.y > 14)
        {
            linearVelocity = Vector3.down;
        }
    }
}
