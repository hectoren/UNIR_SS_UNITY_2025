using UnityEngine;

public class Enemy_1 : EnemyBase
{
    Vector3 linearVelocity = Vector3.left;

    protected override void Move()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);

        if (transform.position.x < -20)
        {
            linearVelocity = Vector3.right;
        }
        if (transform.position.x > 4)
        {
            linearVelocity = Vector3.left;
        }
    }
}