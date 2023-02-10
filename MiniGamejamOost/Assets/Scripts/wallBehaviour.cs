using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBehaviour : MonoBehaviour
{
    public static event Action<float> OnWallEnter;
    [SerializeField] float slowInPercent = 0.5f;
    BoxCollider2D parentCollider;

    private void Start()
    {
        parentCollider = transform.parent.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (parentCollider.name != "Vanishing Block")
            {
                parentCollider.enabled = false;
                OnWallEnter(slowInPercent);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            parentCollider.enabled = true;
        }
    }

}
