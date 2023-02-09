using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Floor")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isOnGround = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "Floor")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isOnGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Floor")
        {
            gameObject.GetComponentInParent<PlayerMovement>().isOnGround = false;
        }
    }
}
