using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour 
{

    public static Score instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    public int yourScore = 0;

    private void Update()
    {
        Debug.Log(yourScore);
    }

}
