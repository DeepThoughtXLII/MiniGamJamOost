using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameObject gameManager;
    private Rigidbody2D rb;
    public GameObject bullet;
    public GameObject shootPoint;
    [SerializeField] private float speedMulti;
    [SerializeField] private float jumpHeight = 10;
    [SerializeField] private float shootTimer = 0.1f;
    [SerializeField] private float rocketJumpHeight = 1;
    public GameObject groundCheck;
    public bool isOnGround = false;
    float shooting;
    Vector3 mouse_pos;
    [SerializeField] Transform gun;
    Vector3 object_pos;
    float angle;
    void Start()
    {
        Time.timeScale = 3;
        shooting = shootTimer;
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
            int jump = Random.Range(0, gameManager.GetComponent<Audio>().jumps.Length);
            gameManager.GetComponent<Audio>().audioSource.PlayOneShot(gameManager.GetComponent<Audio>().jumps[jump]);
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
            int shot = Random.Range(0, gameManager.GetComponent<Audio>().jumps.Length);
            gameManager.GetComponent<Audio>().audioSource.PlayOneShot(gameManager.GetComponent<Audio>().shots[shot]);
            if (GameObject.Find("Rotation").transform.eulerAngles.z <= 280 && GameObject.Find("Rotation").transform.eulerAngles.z >= 260)
            {
                if (isOnGround)
                {
                    rb.AddForce(new Vector2(0, rocketJumpHeight), ForceMode2D.Impulse);
                }
                Instantiate(bullet, new Vector3(shootPoint.transform.position.x, shootPoint.transform.position.y - 0.2f, shootPoint.transform.position.z), shootPoint.transform.rotation);
                gameManager.GetComponent<AmmoCache>().bulletAmount--;
                shootTimer = shooting;
            }
            else
            {
                Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                gameManager.GetComponent<AmmoCache>().bulletAmount--;
                shootTimer = shooting;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "AmmoBox")
        {
            gameManager.GetComponent<Audio>().audioSource.PlayOneShot(gameManager.GetComponent<Audio>().ammoCrate);
            Destroy(collision.collider.gameObject);
            gameManager.GetComponent<AmmoCache>().bulletAmount += 50;
        }
    }
}
