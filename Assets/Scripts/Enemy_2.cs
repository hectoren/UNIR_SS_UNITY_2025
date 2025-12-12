using UnityEngine;

public class Enemy_2 : EnemyBase
{
    Vector3 linearVelocity = Vector3.left;

    protected override void Move()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);

        if (transform.position.x < -25)
        {
            linearVelocity = Vector3.right;
        }
        if (transform.position.x > 14)
        {
            linearVelocity = Vector3.left;
        }
    }
}
