using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private float playerSpeed = 5f;
    public GameObject bullet;
    public GameObject shootPoint;
    [SerializeField]private float speedMulti;
    [SerializeField]private float timer = 1;
    private float maxspeed;
    float duration = 1;
    float timer2;
    void Start()
    {
        timer2 = timer;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        PlayerMove();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerShoot();
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timer2;
            speedMulti = playerSpeed;
            maxspeed = playerSpeed + speedMulti;
            StartCoroutine(Test(playerSpeed, maxspeed));

        }
    }

    void PlayerMove()
    {
        rb.velocity = new Vector2(1 * playerSpeed, rb.velocity.y);
    }
    void PlayerShoot()
    {
        Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
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

}
