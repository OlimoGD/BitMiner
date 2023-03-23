using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip, float volume, float pitch = 1f)
    {
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
