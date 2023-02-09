using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScrolling : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float speedMultiplier;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * (_speed * speedMultiplier) * Time.deltaTime);
    }
}
