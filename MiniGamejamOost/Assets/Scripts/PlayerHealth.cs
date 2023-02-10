using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void killPlayer()
    {
        gameManager.GetComponent<Audio>().audioSource.PlayOneShot(gameManager.GetComponent<Audio>().death);
        Destroy(transform.gameObject);
    }
}
