using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float playerSpeed = 5f;
    public GameObject bullet;
    public GameObject shootPoint;
    [SerializeField] private float speedMulti;
    [SerializeField] private float timer = 1;
    [SerializeField] private float jumpHeight = 10;
    [SerializeField] private float shootTimer = 0.1f;
    public GameObject groundCheck;
    private float maxspeed;
    public bool isOnGround = false;
    float duration = 1;
    float timer2;
    bool accelerate = true;
    float shooting;
    void Start()
    {
        shooting = shootTimer;
        timer2 = timer;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        PlayerMove();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            PlayerShoot();
        }
        if (accelerate)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timer2;
                speedMulti = playerSpeed * 0.1f;
                maxspeed = playerSpeed + speedMulti;
                StartCoroutine(Test(playerSpeed, maxspeed));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse); //creeërt een jump door middel van force
        }
    }

    void PlayerMove()
    {
        if (!isOnGround)
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
    }
    void PlayerShoot()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            shootTimer = 0.1f;
        }
    }
    IEnumerator Test(float startValue, float endValue)
    {
        float time = 0;

        while (time < duration)
        {
            playerSpeed = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Wall")
        {
            accelerate = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Wall")
        {
            accelerate = true;
        }
    }
}
