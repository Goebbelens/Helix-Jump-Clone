using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondMusic : MonoBehaviour
{
    private AudioSource _audio;
    public bool MusicOn = false;
    private static FondMusic fondMusic;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audio = GetComponent<AudioSource>();

        if (fondMusic == null) fondMusic = this;
        else Destroy(gameObject);
    }

    public void PlayMusic()
    {
        if (_audio.isPlaying) return;
        MusicOn = true;
        _audio.Play();
    }

    public void StopMusic()
    {
        if (!_audio.isPlaying) return;
        MusicOn = false;
        _audio.Stop();
    }

    private void Start()
    {
        if(MusicOn)
        {
            PlayMusic();
        }
    }

}
