using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float bulletSpeed = 20f;
    private float lifeTime = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, lifeTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyDeath enemycheck = collision.collider.GetComponent<EnemyDeath>();

        if (enemycheck != null)
        {
            Destroy(gameObject);
            enemycheck.TakeDamage();
            Debug.Log("headshawt");
        }
        else if (collision.gameObject.name != gameObject.name)
        {
            Destroy(gameObject);
        }
    }
}
