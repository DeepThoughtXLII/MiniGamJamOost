using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] float hp = 100;
    private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            gameManager.GetComponent<Audio>().audioSource.PlayOneShot(gameManager.GetComponent<Audio>().wallDeath);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;
    }
}
