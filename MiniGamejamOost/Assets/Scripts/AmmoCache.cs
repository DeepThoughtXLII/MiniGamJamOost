using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCache : MonoBehaviour
{
    public List <Bullet> bullets = new List<Bullet>();
    int bulletcount;
    // Start is called before the first frame update
    void Start()
    {
        bulletcount = bullets.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (bullets.Count > bulletcount)
        {
            foreach (Bullet bullet in bullets)
            {
                if (bullet == bullets[bulletcount])
                {
                    print("test");
                }
            }
        }
    }
}
