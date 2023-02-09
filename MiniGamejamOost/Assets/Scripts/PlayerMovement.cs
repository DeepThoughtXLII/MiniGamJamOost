using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float playerSpeed = 5f;
    public GameObject bullet;
    public GameObject shootPoint;
    private bool facingRight = true;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        PlayerMove();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerShoot();
        }
    }

    void PlayerMove()
    {
        rigidbody.velocity = new Vector2(1 * playerSpeed, rigidbody.velocity.y);
    }
    void PlayerShoot()
    {
        Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
    }

}
