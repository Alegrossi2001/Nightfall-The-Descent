using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip chaseMusic;
    private AudioSource audioSource;
    bool isMusicPlaying;
    public static MusicManager MusicManagerInstance { get; private set; }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        MusicManagerInstance = this;
    }

    public void PlayMusic(bool isChasing)
    {
        if (isChasing)
        {
            if (isMusicPlaying == false)
            {
                audioSource.clip = chaseMusic;
                audioSource.Play();
                isMusicPlaying = true;
            }
        }
        else 
        {
            audioSource.clip = null;
            isMusicPlaying = false;
            audioSource.Play();
        }
    }
}
