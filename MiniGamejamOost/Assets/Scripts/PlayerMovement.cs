using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameObject gameManager;
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
    Vector3 mouse_pos;
    [SerializeField] Transform gun;
    Vector3 object_pos;
    float angle;
    void Start()
    {
        Time.timeScale = 3;
        shooting = shootTimer;
        timer2 = timer;
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");
    }


    void Update()
    {
        PlayerMove();
        #region shooting
        if (Input.GetKey(KeyCode.Mouse0))
        {
            PlayerShoot();
        }
        #endregion
        #region jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
        #endregion
        #region ammoadding
        if (Input.GetKey(KeyCode.Backspace))
        {
            gameManager.GetComponent<AmmoCache>().bulletAmount++;
        }
        #endregion
        #region rotateGun
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(gun.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        GameObject.Find("Rotation").transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        #endregion
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
        if (shootTimer <= 0 && gameManager.GetComponent<AmmoCache>().bulletAmount >= 1)
        {
            Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            gameManager.GetComponent<AmmoCache>().bulletAmount--;
            shootTimer = shooting;
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
