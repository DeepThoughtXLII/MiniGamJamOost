using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("HighscoreScene");
        Destroy(transform.gameObject);
    }
}
