using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScrolling : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float _speedCap = 10;

    float scoreMulti = 1;

    private void Start()
    {
        wallBehaviour.OnWallEnter += slowLevel;
    }

    private void OnDestroy()
    {
        wallBehaviour.OnWallEnter -= slowLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
        _speed *= speedMultiplier;
        scoreMulti = scoreMulti + _speed;
        Score.instance.yourScore = (int)scoreMulti;
        if(_speed > _speedCap)
        {
            _speed = _speedCap;
        }
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }


    private void slowLevel(float slowPercent)
    {
        _speed = _speed * (1 - slowPercent);
    }
    
}
