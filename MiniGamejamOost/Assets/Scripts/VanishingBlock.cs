using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingBlock : MonoBehaviour
{
    public bool dissapear = false;
    [SerializeField] private float secToDestroy = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dissapear)
        {
            Destroy(gameObject, secToDestroy);
        }
    }
}
