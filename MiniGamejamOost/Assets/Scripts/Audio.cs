using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] jumps;
    public AudioClip[] shots;
    public AudioClip wallDeath;
    public AudioClip death;
    public AudioClip ammoCrate;
    public AudioClip loopedMusic;
    private float time;

    void Start()
    {
        time = 30;
        audioSource.PlayOneShot(loopedMusic);
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 30;
            audioSource.PlayOneShot(loopedMusic);
        }
    }
}
