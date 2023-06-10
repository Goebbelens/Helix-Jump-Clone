using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip AudioClip;
    [Min(0)]
    public float Volume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    public void PlayCurrentSound()
    {
        _audio.PlayOneShot(AudioClip, Volume);
    }
}
