using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")] public AudioSource musicSource;
    public AudioSource sfxSource;
    [Header("Audio Clip")] public AudioClip background;
    public AudioClip click;
    public AudioClip jump;
    public AudioClip hit;
    public AudioClip block;
    public AudioClip apple;
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
