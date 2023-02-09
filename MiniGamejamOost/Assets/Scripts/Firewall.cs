using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewall : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float speedMultiplier;

    // Update is called once per frame
    void Update()
    {
        _speed *= speedMultiplier;
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}
